📝 MediNotes
Empowering Healthcare Notes with Intelligent Summarization

🚀 Project Overview
MediNotes is a healthcare AI web application that transforms free-text clinical notes into structured SOAP format — Subjective, Objective, Assessment, and Plan — instantly using Azure OpenAI services. Built with ASP.NET MVC (.NET 8) and integrated with Azure AI Foundry, MediNotes aims to save clinicians valuable time, reduce manual errors, and standardize patient records for better care delivery.

📈 Key Features
✏️ Simple Chat Interface for entering patient notes
🤖 Real-time AI Agent response with SOAP structured format
🔒 Secure Azure AI Integration using Project Connection & Model Deployment
⚡ Fast & Scalable with Azure cloud services
🎯 Formatted Chat View showing organized healthcare data

🔥 Why MediNotes?
Doctors can quickly structure notes without manual formatting.
Improves clinical documentation quality.
Reduces time spent on paperwork.
Standardized notes help in faster diagnosis and care planning.

🖥️ How it Works
1. Doctor Inputs Notes: Types or pastes free-text patient encounter notes in the chat window.
2. AI Agent Processes: MediNotes sends the input to Azure OpenAI GPT-4o via AI Foundry Project Connection and waits for structured output.
3. SOAP Format Response: The AI agent replies with a properly formatted SOAP note inside the web app chat interface.
4. Realtime Interaction: Users can iteratively refine and update notes if needed.

⚙️ Setup Instructions
1. Clone the Repository
git clone [https://github.com/your-username/MediNotes.git](https://github.com/rajupadhara2025/MediNotes.git)

2. Update appsettings.json
{
  "AzureOpenAI": {
    "MODEL_URI": "https://xxxx-xxxxxx.openai.azure.com/",
    "MODEL": "gpt-4o",
    "MODEL_DEPLOYMENT_NAME": "gpt-4o-name",
    "API_KEY": "xxxxxxxxxx"
  }
}
