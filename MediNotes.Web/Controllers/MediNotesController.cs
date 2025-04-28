using MediNotes.Web.Models;
using MediNotes.Web.Services;
using Microsoft.AspNetCore.Mvc;

namespace MediNotes.Web.Controllers
{
    public class MediNotesController : Controller
    {
        private readonly OpenAIService _openAIService;
        private static List<ChatMessage> _chatHistory = new List<ChatMessage>();

        public MediNotesController(OpenAIService openAIService)
        {
            _openAIService = openAIService;
        }

        public IActionResult Index()
        {
            return View(_chatHistory);
        }

        [HttpPost]
        public async Task<IActionResult> SendMessage(string userMessage)
        {
            if (!string.IsNullOrWhiteSpace(userMessage))
            {
                // Add doctor message
                _chatHistory.Add(new ChatMessage { Role = "Doctor", Message = userMessage });

                // Get agent reply
                var agentReply = await _openAIService.GetChatCompletionAsync(userMessage);

                // Add agent reply to chat
                _chatHistory.Add(new ChatMessage { Role = "Agent", Message = agentReply });
            }

            return PartialView("_ChatPartial", _chatHistory);
        }
    }
}
