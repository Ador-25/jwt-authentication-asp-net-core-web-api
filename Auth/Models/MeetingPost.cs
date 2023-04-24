namespace Auth.Models
{
    public class MeetingPost
    {
        public Guid Id { get; set; }
        public string MeetingUrl { get; set; }
        public string Time { get; set; }
        public string Date { get; set; }
        public List<string> Emails { get; set; }
        /*{
          "meetingUrl": "wwq-mma-pqi",
          "time": "2:00",
          "date": "22-4-2023",
          "emails": [
            "ador29@gmail.com","ador25@yahoo.com"
          ]
            }*/
    }
}
