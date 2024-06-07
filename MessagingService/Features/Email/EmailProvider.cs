namespace MessagingService.Features.Email;

public class EmailProvider : IEmailProvider
{
    public bool SendEmail(string message)
    {
        // Calling some provider
        // Processing ....
        Random rnd = new Random();
        var num = rnd.Next(1, 100);

        return num > 5;
    }
}