using MessagingService.Common.Data;

namespace MessagingService.Features.Inbox;

class InboxService(ApplicationDbContext dbContext)
{
    internal async Task<bool> SentNotification(SendMessageCommand command, CancellationToken token)
    {
        // var holidays = await dbContext.Holidays.ToArrayAsync(token);
        // var holidayDates = holidays.Select(x => x.Date);
        // return CongestionTaxCalculator.Core.CongestionTaxCalculator.GetTax(vehicleType, dates, holidayDates.ToArray());
        return true;
    }
}