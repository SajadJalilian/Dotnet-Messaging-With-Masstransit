namespace ServiceContracts;

public record SendSmsBusRequest(string Message, int UserId) : BusRequest;