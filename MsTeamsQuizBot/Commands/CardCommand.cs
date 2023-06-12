using Microsoft.Bot.Builder;
using Microsoft.Bot.Schema;
using Microsoft.TeamsFx.Conversation;
using MsTeamsQuizBot.Cards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Tavis.UriTemplates;

namespace MsTeamsQuizBot.Commands;
internal class CardCommand : ITeamsCommandHandler
{
    public IEnumerable<ITriggerPattern> TriggerPatterns => new List<ITriggerPattern>()
    {
        new StringTrigger("card"),
    };

    public async Task<ICommandResponse> HandleCommandAsync(ITurnContext turnContext, CommandMessage message, CancellationToken cancellationToken = default)
    {
        await Task.CompletedTask;

        //var activities = new Activity[]
        //{
        //    new Activity { Text = "Hello there!", Type = ActivityTypes.Message },
        //    new Activity { Value = 30000, Type = ActivityTypes.Delay },
        //    new Activity { Text = "woah!!", Type = ActivityTypes.Message },
        //};

        //await turnContext.SendActivitiesAsync(activities, cancellationToken);
        //return null;

        //var card = new Test2();
        //return new ActivityCommandResponse(card.CreateActivity(new() { Title = "This is a test" }));
        var card = new Test();
        var s = new ActivityCommandResponse(card.CreateActivity(new() { Title = "This is a test" }));
        return s;
    }
}