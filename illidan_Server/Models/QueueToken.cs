using Google.Protobuf.WellKnownTypes;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace illidan_Server.Models
{
    public class QueueToken
    {
        public QueueToken(int userId)
        {
            UserId=userId;
        }
        public int? Token { get; set; }
        [Key]
        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }
    }
}