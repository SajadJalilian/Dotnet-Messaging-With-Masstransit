namespace MessagingService.Providers.Sms;

public interface ISmsProvider
{
    public bool SendSms(string message);
}