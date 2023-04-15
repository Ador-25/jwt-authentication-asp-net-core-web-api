using System.ComponentModel.DataAnnotations;

namespace Auth.Models
{
    public class Meeting
    {
        [Key]
        public Guid Id { get; set; }
        public string MeetingUrl { get; set; }
        public string PatientName { get; set; }
        public string Email  { get; set; }
    }
}
