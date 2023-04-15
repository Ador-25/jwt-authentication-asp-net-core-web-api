using System.ComponentModel.DataAnnotations;

namespace Auth.Models
{
    public class Patient
    {
        [Key]
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        public string? RiskScale { get; set; }
        public string Father { get; set; }
        public string Mother { get; set; }
        public string ChildName { get; set; }
        public string? LastDate { get; set; }
        public string? DateOfBirth { get; set; }
        public bool? Action { get; set; }
    }
}
