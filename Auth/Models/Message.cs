using System.ComponentModel.DataAnnotations;

namespace Auth.Models
{
    public class Message
    {
        [Key]
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Text { get; set; }
    }
}
