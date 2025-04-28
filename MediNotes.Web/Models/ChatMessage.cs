namespace MediNotes.Web.Models
{
    public class ChatMessage
    {
        public string? Role { get; set; }  // Doctor or Agent
        public string? Message { get; set; }
    }
}
