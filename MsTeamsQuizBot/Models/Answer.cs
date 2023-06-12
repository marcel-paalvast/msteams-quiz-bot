using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MsTeamsQuizBot.Models;
public class Answer
{
    public string Id { get; set; }
    public string QuizId { get; set; }
    public string QuestionId { get; set; }
    public string UserId { get; set; }
    public char UserAnswer { get; set; }
    public string UserName { get; set; }
}
