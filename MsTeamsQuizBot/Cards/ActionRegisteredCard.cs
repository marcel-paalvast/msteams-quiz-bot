using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MsTeamsQuizBot.Cards;
public class ActionRegisteredCard : Card<Registered>
{
    public override string Template => """
        {
            "type": "AdaptiveCard",
            "$schema": "http://adaptivecards.io/schemas/adaptive-card.json",
            "version": "1.5",
            "body": [
                {
                    "type": "TextBlock",
                    "text": "Your action has been registered",
                    "wrap": true,
                    "size": "Medium",
                    "horizontalAlignment": "Center"
                }
            ]
        }
        """;
}

public class Registered
{ }
