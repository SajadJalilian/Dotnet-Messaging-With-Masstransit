namespace MessagingService.Providers.Email;

public interface IEmailProvider
{
    public bool SendEmail(string message);
}