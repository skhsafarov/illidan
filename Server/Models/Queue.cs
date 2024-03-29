using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Server.Models;

[Table("Queues")] public class Queue
{
    public Queue()
    {
    }
    public Queue(int ownerId, string name, string? imageLink, int count=0, int lastAnimal = 0, int lastColor = 0)
    {
        OwnerId=ownerId;
        Name=name;
        ImageLink=imageLink;
        Count=count;
        LastAnimal=lastAnimal;
        LastColor=lastColor;
    }

    [Key] public int Id { get; set; }
    [ForeignKey(nameof(Owner))] public int OwnerId { get; set; }
    [Required] [StringLength(50)] public string Name { get; set; }
    public string? ImageLink { get; set; }
    public int Count { get; set; }
    public int LastAnimal { get; set; }
    public int LastColor { get; set; }

    public User Owner { get; set; }
    public ICollection<QueueToken> QueueTokens { get; set; }
}