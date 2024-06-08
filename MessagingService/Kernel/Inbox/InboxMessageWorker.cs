using Core;
using Core.LockManager;
using MessagingService.Common;
using MessagingService.Common.Data;
using MessagingService.Providers.Email;
using MessagingService.Providers.Sms;

namespace MessagingService.Kernel.Inbox;

public class InboxMessageWorker(IServiceProvider serviceProvider) : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        using var scope = serviceProvider.CreateScope();
        var applicationDbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        var messages = applicationDbContext.Set<InboxMessage>();

        var smsProvider = scope.ServiceProvider.GetRequiredService<ISmsProvider>();
        var emailProvider = scope.ServiceProvider.GetRequiredService<IEmailProvider>();
        var timeProvider = scope.ServiceProvider.GetRequiredService<ICustomTimeProvider>();
        var lockManager = scope.ServiceProvider.GetRequiredService<ILockManager>();

        bool isLocked;
        while (!stoppingToken.IsCancellationRequested)
        {
            var message = messages.FirstOrDefault(x => x.Processed == false);
            if (message is null) continue;
            
            isLocked = await lockManager.TryToLockAsync(
                key: $"inbox-worker-message-lock-{message.MessageId}",
                duration: new TimeSpan(0, 1, 0)
            );
            if (isLocked)continue;

            if (!message.SmsSend)
            {
                var isSmsSend = smsProvider.SendSms(message.Content);
                if (isSmsSend) message.SmsSend = true;
            }

            if (!message.EmailSend)
            {
                var isEmailSend = emailProvider.SendEmail(message.Content);
                if (isEmailSend) message.EmailSend = true;
            }

            if (message is { SmsSend: true, EmailSend: true })
            {
                message.Processed = true;
                message.ProcessedOn = timeProvider.UtcNow();
            }

            await applicationDbContext.SaveChangesAsync(stoppingToken);

            await Task.Delay(MessagingConstants.WorkerDelay, stoppingToken);
        }
    }
}