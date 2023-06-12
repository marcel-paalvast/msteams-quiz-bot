using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MsTeamsQuizBot.Cards;
public class AnsweredCard : Card<Answered>
{
    public override string Template => """
        {
            "type": "AdaptiveCard",
            "$schema": "http://adaptivecards.io/schemas/adaptive-card.json",
            "version": "1.5",
            "body": [
                {
                    "type": "TextBlock",
                    "text": "Your answer has been submitted",
                    "wrap": true,
                    "size": "Medium",
                    "horizontalAlignment": "Center"
                }
            ]
        }
        """;
}

public class Answered
{ }