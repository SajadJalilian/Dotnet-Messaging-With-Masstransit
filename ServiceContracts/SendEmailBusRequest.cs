namespace ServiceContracts;

public record SendEmailBusRequest(string Message, int Userid): BusRequest;