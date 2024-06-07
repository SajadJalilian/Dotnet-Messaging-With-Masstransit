namespace ServiceContracts;

public record SendEmailBusRequest() : BusRequest
{
    public int UserId { get; init; }
    public required string Message { get; init; }
}