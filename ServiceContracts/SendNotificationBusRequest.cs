namespace ServiceContracts;

public record SendNotificationBusRequest(string Message, int Userid,
    NotificationBusType[] NotificationBusTypes)
    : BusRequest;