using DotnetGeminiSDK.Client;
using DotnetGeminiSDK.Config;
using DotnetGeminiSDK.Model.Response;
using System;
using System.Threading.Tasks;

public class TestGemini {
    private readonly GeminiClient _geminiClient;

    public TestGemini()
    {
        _geminiClient = new GeminiClient(new GoogleGeminiConfig()
        {
            ApiKey = "AIzaSyDaHd0Qehs61qNwV3RgXVeLp8TFcRbiOCw",
        });
    }
    
    public async Task Example()
    {
        GeminiMessageResponse response = await _geminiClient.TextPrompt("Bạn là một trợ lý ảo tên là Mirabo, hãy trả lời một cách lịch sự. Hãy cho tôi biết tên của bạn là gì?");
        Console.WriteLine("Gemini Response:");
        Console.WriteLine($"Prompt Feedback: {response.PromptFeedback}");
        Console.WriteLine("Candidates:", response.Candidates);
        foreach (var candidate in response.Candidates)
        {
            Console.WriteLine($"- Content: {candidate.Content?.Parts?.FirstOrDefault()?.Text}");
        }
    }

    public static async Task Main(string[] args)
    {
        TestGemini testGemini = new TestGemini();
        await testGemini.Example();
    }
}