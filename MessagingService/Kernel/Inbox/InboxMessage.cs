using System.ComponentModel.DataAnnotations;
using MessagingService.Common;
using MessagingService.Common.Data;

namespace MessagingService.Kernel.Inbox;

public class InboxMessage : IEntity
{
    public int Id { get; set; }

    public required Guid MessageId { get; set; }

    public required MessageType MessageType { get; set; }

    [MaxLength(MessagingConstants.MessageContentMaxLength)]
    public required string Content { get; set; }

    public DateTime CreatedOn { get; set; }

    public DateTime? ProcessedOn { get; set; }

    public bool Processed { get; set; }
}