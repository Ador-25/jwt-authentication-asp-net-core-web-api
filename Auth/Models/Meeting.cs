using System.ComponentModel.DataAnnotations;

namespace Auth.Models
{
    public class Meeting
    {
        [Key]
        public Guid Id { get; set; }
        public string MeetingUrl { get; set; }
        public string Time { get; set; }
        public string Date { get; set; }
        public bool Success { get; set; } = false;
    }

}
