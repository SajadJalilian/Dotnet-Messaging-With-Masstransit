namespace MessagingService.Features.Sms;

public interface ISmsProvider
{
    public bool SendSms(string message);
}