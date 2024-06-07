namespace ServiceContracts;

public record SendMessageBusRequest()
    : BusRequest
{
    public int UserId { get; init; }
    public required string Content { get; init; }
    public MessageBusType MessageType { get; init; } = MessageBusType.Full;
}