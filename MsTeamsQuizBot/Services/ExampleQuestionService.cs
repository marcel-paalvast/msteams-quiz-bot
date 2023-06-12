using MsTeamsQuizBot.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MsTeamsQuizBot.Services;
public class ExampleQuestionService : IQuestionService
{
    public Task<Question> CreateQuestionAsync(string topic, string language)
    {
        return Task.FromResult(new Question()
        {
            Id = Guid.NewGuid().ToString(),
            Description = "What is the best fruit?",
            Answers = new string[] { "Apple", "Banana", "Cherry", "Date" },
            CorrectAnswer = 'C',
        });
    }
}
