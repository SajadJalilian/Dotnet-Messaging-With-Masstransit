namespace MessagingService.Common;

internal static class MessagingConstants
{
    internal const string DefaultConnection = "DefaultConnection";

    internal const int MessageContentMaxLength = 1000;
    internal const int WorkerDelay = 5000; // Calibrate this base on providers response time
}