namespace MessagingService.Features.Sms;

public class SmsProvider : ISmsProvider
{
    public bool SendSms(string message)
    {
        // Calling some provider
        // Processing ....
        Random rnd = new Random();
        var num = rnd.Next(1, 100);

        return num > 5;
    }
}