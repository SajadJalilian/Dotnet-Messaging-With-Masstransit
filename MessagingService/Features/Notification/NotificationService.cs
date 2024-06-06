using MessagingService.Common.Data;

namespace MessagingService.Features.Notification;

class NotificationService(ApplicationDbContext dbContext)
{
    internal async Task<bool> SentNotification(SendNotificationCommand command, CancellationToken token)
    {
        // var holidays = await dbContext.Holidays.ToArrayAsync(token);
        // var holidayDates = holidays.Select(x => x.Date);
        // return CongestionTaxCalculator.Core.CongestionTaxCalculator.GetTax(vehicleType, dates, holidayDates.ToArray());
        return true;
    }
}