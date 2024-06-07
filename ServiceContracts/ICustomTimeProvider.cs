namespace ServiceContracts;

public interface ICustomTimeProvider
{
    public DateTime UtcNow();
}

public class CustomTimeProvider : ICustomTimeProvider
{
    public DateTime UtcNow() => DateTime.UtcNow;
}