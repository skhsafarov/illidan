using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Server.Models;

[Table("Users")]
public class User
{
    public User(string role = "User", int attempts = 10)
    {
        Role = "User";
        Attempts = 10;
        Expiration=DateTime.UtcNow.AddMinutes(3);
    }

    public User(string firstName, string phone, string code, string role = "User", int attempts = 10) : base()
    {
        FirstName = firstName;
        Role=role;
        Phone=phone;
        Code=code;
        Attempts=attempts;
    }

    [Key] public int Id { get; set; }
    [Required][StringLength(50)] public string FirstName { get; set; }
    [StringLength(50)] public string? LastName { get; set; }
    [Required][StringLength(50)] public string Role { get; set; }
    [Required][StringLength(16)] public string Phone { get; set; }
    [StringLength(6)] public string? Code { get; set; }
    public int Attempts { get; set; }
    public DateTime Expiration { get; set; }
    public ICollection<QueueToken> QueueTokens { get; set; }
}