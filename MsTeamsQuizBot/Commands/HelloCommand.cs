using Microsoft.Bot.Builder;
using Microsoft.Bot.Schema;
using Microsoft.TeamsFx.Conversation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MsTeamsQuizBot.Commands;
internal class HelloCommand : ITeamsCommandHandler
{
    public IEnumerable<ITriggerPattern> TriggerPatterns => new List<ITriggerPattern>()
    {
        new StringTrigger("hello"),
        //new RegExpTrigger("hello"),
    };

    public async Task<ICommandResponse> HandleCommandAsync(ITurnContext turnContext, CommandMessage message, CancellationToken cancellationToken = default)
    {
        var activities = new Activity[]
        {
            new() { Type = ActivityTypes.Typing },
            new() { Type = ActivityTypes.Delay, Value = 5000 },
            new() { Type = ActivityTypes.Message, Text = $"Hello {turnContext.Activity.From.Name}!" },
        };

        await turnContext.SendActivitiesAsync(activities, cancellationToken);

        return null;
        //return new ActivityCommandResponse(activities[2]);
    }
}