using OpenAI.Chat;
using Azure.AI.OpenAI;
using Azure;


namespace MediNotes.Web.Services
{
    public class OpenAIService
    {
                
        private ChatClient _chatClient = null;
        private List<ChatMessage> _prompt = null;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public OpenAIService(IConfiguration configuration, IWebHostEnvironment hostEnv)
        {
            _hostingEnvironment = hostEnv;

            // Get Model URI, API Key + Model Deployment from appsettings.json
            var model_uri = configuration["AzureOpenAI:MODEL_URI"];
            var model = configuration["AzureOpenAI:MODEL"];
            var model_deployment = configuration["AzureOpenAI:MODEL_DEPLOYMENT_NAME"];
            var api_key = configuration["AzureOpenAI:API_KEY"];

            if (string.IsNullOrEmpty(model_uri) || string.IsNullOrEmpty(model_deployment))
            {
                throw new ArgumentException("MODEL_URI or MODEL_DEPLOYMENT_NAME not configured properly.");
            }


            var endpoint = new Uri(model_uri);
            AzureOpenAIClient azureClient = new(endpoint,
                new AzureKeyCredential(api_key));
                
            _chatClient = azureClient.GetChatClient(model_deployment);

            string promptFilePath = Path.Combine(_hostingEnvironment.WebRootPath, "prompts", "prompt.txt");            
            var filePrompt = File.ReadAllText(promptFilePath);

            // Initialize prompt with system message
            _prompt = new List<ChatMessage>(){
                    new SystemChatMessage(filePrompt)
              };
        }

        public async Task<string> GetChatCompletionAsync(string userMessage)
        {
            // Get a chat completion
            _prompt.Add(new UserChatMessage(userMessage));
            ChatCompletion completion = await _chatClient.CompleteChatAsync(_prompt);
            var completionText = completion.Content[0].Text;
            
            _prompt.Add(new AssistantChatMessage(completionText));
            return completionText;
        }
    }
}
