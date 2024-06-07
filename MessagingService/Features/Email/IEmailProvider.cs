namespace MessagingService.Features.Email;

public interface IEmailProvider
{
    public bool SendEmail(string message);
}