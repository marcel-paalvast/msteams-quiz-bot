using Microsoft.Bot.Builder;
using Microsoft.Bot.Schema;
using Microsoft.TeamsFx.Conversation;
using MsTeamsQuizBot.Cards;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MsTeamsQuizBot.CardActions;
public class InitAction : IAdaptiveCardActionHandler
{
    public const string Verb = "test";
    public string TriggerVerb => Verb;

    public AdaptiveCardResponse AdaptiveCardResponse => AdaptiveCardResponse.ReplaceForInteractor;

    public Task<InvokeResponse> HandleActionInvokedAsync(ITurnContext turnContext, object cardData, CancellationToken cancellationToken = default)
    {
        var data = ((JObject)cardData).ToObject<CardData>();

        if (data.Refresh == "instigator")
        {
            var instigatorCard = new AnsweredCard().CreateActivity(new Answered());
            return Task.FromResult(InvokeResponseFactory.AdaptiveCard(instigatorCard));
        }

        return Task.FromResult(InvokeResponseFactory.TextMessage("Answer submitted"));
        return Task.FromResult(new InvokeResponse() { Status = 200 });
    }

    private class CardData
    {
        public string User { get; set; }
        public string Refresh { get; set; }
    }
}
