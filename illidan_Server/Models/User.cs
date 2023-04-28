using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace illidan_Server.Models;

[Table("Users")]
public class User
{
    public User(string firstName)
    {
        FirstName=firstName;
    }

    [Key] public int Id { get; set; }
    [Required][StringLength(50)] public string FirstName { get; set; }
    [StringLength(50)] public string? LastName { get; set; }
    [Required][DefaultValue("User")][StringLength(50)] public string Role { get; set; }
    [Required][StringLength(16)] public string Phone { get; set; }
    public string Code { get; set; }
    [DefaultValue(10)] public int Attempts { get; set; }
    [DefaultValue("2021-01-01T00:00:00Z")] public DateTime Expiration { get; set; }
}