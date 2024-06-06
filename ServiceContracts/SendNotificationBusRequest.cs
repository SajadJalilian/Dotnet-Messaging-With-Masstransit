namespace ServiceContracts;

public record SendNotificationBusRequest(string Message, int Userid): BusRequest;