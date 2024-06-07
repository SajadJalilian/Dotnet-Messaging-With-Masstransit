namespace ServiceContracts;

public record SendNotificationBusRequest(string Message, int UserId,
    MessageBusType MessageType = MessageBusType.Full)
    : BusRequest;