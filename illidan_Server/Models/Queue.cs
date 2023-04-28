using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace illidan_Server.Models;

[Table("Queues")] public class Queue
{
    [Key] public int Id { get; set; }
    [ForeignKey(nameof(Owner))] public int OwnerId { get; set; }
    [Required] [StringLength(50)] public string Name { get; set; }
    public string? ImageLink { get; set; }
    public int Count { get; set; }
    public int LastAnimal { get; set; }
    public int LastColor { get; set; }
    public User Owner { get; set; }
}