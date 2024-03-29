using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Server.Models;

[Table("Bids")] public class Bid
{
    [Key] public int Id { get; set; }
    [Required] public int OwnerId { get; set; }
    public int? ÑounteragentId { get; set; }
    [Required][StringLength(50)] public string FromCurrency { get; set; }
    [Required][StringLength(50)] public string ToCurrency { get; set; }
    [Required] public decimal OwnedAmount { get; set; }
    [Required] public decimal RequiredAmount { get; set; }
    [Required][StringLength(16)] public string OwnerDestinationCard { get; set; }
    [StringLength(16)] public string? ÑounteragentDestinationCard { get; set; }
    [Required] public DateTime CreatedAt { get; set; }
    [Required] public DateTime UpdatedAt { get; set; }
    [Required][StringLength(50)] public string Status { get; set; }
    [ForeignKey(nameof(OwnerId))] public virtual User Owner { get; set; }
    [ForeignKey(nameof(ÑounteragentId))] public virtual User? Ñounteragent { get; set; }
}