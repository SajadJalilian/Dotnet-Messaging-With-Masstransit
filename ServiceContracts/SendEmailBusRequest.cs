namespace ServiceContracts;

public record SendEmailBusRequest(string Message, int UserId): BusRequest;