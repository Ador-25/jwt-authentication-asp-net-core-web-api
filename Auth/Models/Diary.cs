using System.ComponentModel.DataAnnotations;

namespace Auth.Models
{
    public class Diary
    {
        [Key]
        public Guid Id { get; set; }
        public string ChildName { get; set; }
        public string? DateOfBirth { get; set; }
        public string Medication { get; set; }
        public string YesOrNo { get; set; }
        public bool Action { get; set; }
        public string? Date { get; set; }
    }
}
