using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MsTeamsQuizBot.Models;
public class Quiz
{
    public string Id { get; set; }
    public string Language { get; set; }
    public string Topic { get; set; }
    public string ApiKey { get; set; }
}
