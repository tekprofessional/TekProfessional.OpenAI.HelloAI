using OpenAI.NET.Clients.OpenAIs;
using OpenAI.NET.Models.Configurations;
using OpenAI.NET.Models.Services.Foundations.Completions;
using System.Text;

namespace TekProfessional.OpenAI.HelloAI
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var openAiApiConfigurations = new ApiConfigurations
            {
                ApiKey = "",
                OrganizationId = ""
            };

            var openAiClient = new OpenAIClient(openAiApiConfigurations);
            var promptMessage = $"Human: I am TekProfessional, using the recently released Standard.AI.OpenAI nuget library to chat with you\r\n";
            var inputCompletion = new Completion
            {
                Request = new CompletionRequest
                {
                    Prompt = new string[] { promptMessage },
                    MaxTokens = 300,
                    Model = "text-davinci-003"
                }
            };

            Completion resultCompletion =
                await openAiClient.Completions.PromptCompletionAsync(
                    inputCompletion);

            Console.WriteLine(promptMessage);
            Array.ForEach(resultCompletion.Response.Choices, choice => Console.WriteLine(choice.Text));
        }

    }
}