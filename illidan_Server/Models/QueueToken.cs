using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace illidan_Server.Models;

[Table("QueueTokens")] public class QueueToken
{
    [Key] public int Id { get; set; }
    [ForeignKey(nameof(Owner))] public int OwnerId { get; set; }
    [ForeignKey(nameof(Queue))] public int QueueId { get; set; }
    [Required] public int Animal { get; set; }
    [Required] public int Color { get; set; }
    public User Owner { get; set; }
    public Queue Queue { get; set; }
}