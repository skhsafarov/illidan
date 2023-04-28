using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace illidan_Server.Models;

[Table("Bids")] public class Bid
{
    [Key] public int Id { get; set; }
    [ForeignKey(nameof(Owner))][Required] public int OwnerId { get; set; }
    [ForeignKey(nameof(Ñounteragent))] public int? ÑounteragentId { get; set; }
    [Required][StringLength(50)] public string FromCurrency { get; set; }
    [Required][StringLength(50)] public string ToCurrency { get; set; }
    [Required] public decimal OwnedAmount { get; set; }
    [Required] public decimal RequiredAmount { get; set; }
    [Required][StringLength(16)] public string OwnerDestinationCard { get; set; }
    [StringLength(16)] public string? ÑounteragentDestinationCard { get; set; }
    [Required] public DateTime CreatedAt { get; set; }
    [Required] public DateTime UpdatedAt { get; set; }
    [Required][StringLength(50)] public string Status { get; set; }
    public User Owner { get; set; }
    public User Ñounteragent { get; set; }
}