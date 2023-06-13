using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MsTeamsQuizBot.Models;
public class Question
{
    public string Id { get; set; }
    public string QuizId { get; set; }
    public string Description { get; set; }
    public string[] Answers { get; set; }
    public char CorrectAnswer { get; set; }
    public bool Locked { get; set; }
}
