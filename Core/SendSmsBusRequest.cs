namespace Core;

public record SendSmsBusRequest() : BusRequest
{
    public int UserId { get; init; }
    public string Message { get; init; }
}