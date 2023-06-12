using AdaptiveCards.Templating;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Schema;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MsTeamsQuizBot.Cards;

public class Image : ITemplate<TestInput>
{
    public string Template { get; } = "Test";
    public TestInput Data { get; set; }
}

internal class Test
{
    public const string Template = """
        {
            "$schema": "http://adaptivecards.io/schemas/adaptive-card.json",
            "type": "AdaptiveCard",
            "version": "1.5",
            "refresh": {
                "action": {
                    "type": "Action.Execute",
                    "title": "Refresh",
                    "verb": "instigator",
                },
                "userIds": ["29:1LqUWK2sTKkYN4QFWMc1TznD2-Ez7ya6o9sfHjfSVK8sU2St4l_BVotbhhH7FJm182XkmMiWfXO_ha1v3jSmB7w"]
            },
            "body": [
                {
                    "type": "TextBlock",
                    "size": "medium",
                    "weight": "bolder",
                    "text": "${title}",
                    "horizontalAlignment": "center",
                    "wrap": true,
                    "style": "heading"
                },
                {
                    "type": "Input.Text",
                    "id": "user",
                    "label": "Username",
                    "isRequired": true,
                    "errorMessage": "Username is required"
                }
            ],
            "actions": [
                {
                    "type": "Action.Execute",
                    "title": "Send",
                    "verb": "test"
                }
            ]
        }
        """;

    //public const string Template = """
    //    {
    //        "$schema": "http://adaptivecards.io/schemas/adaptive-card.json",
    //        "type": "AdaptiveCard",
    //        "version": "1.5",
    //        "body": [
    //            {
    //                "type": "TextBlock",
    //                "size": "medium",
    //                "weight": "bolder",
    //                "text": "${Title}",
    //                "horizontalAlignment": "center",
    //                "wrap": true,
    //                "style": "heading"
    //            },
    //            {
    //                "type": "Input.Text",
    //                "id": "user",
    //                "label": "Username",
    //                "isRequired": true,
    //                "errorMessage": "Username is required"
    //            }
    //        ],
    //        "actions": [
    //            {
    //                "type": "Action.Execute",
    //                "title": "Send",
    //                "verb": "test"
    //            }
    //        ]
    //    }
    //    """;

    public IMessageActivity CreateActivity(TestInput input)
    {
        var cardContent = new AdaptiveCardTemplate(Template).Expand(input);

        return MessageFactory.Attachment(new Attachment()
        {
            ContentType = "application/vnd.microsoft.card.adaptive",
            Content = JsonConvert.DeserializeObject(cardContent),
        });
    }
}

internal class Test2
{
    public const string Template = """
        {
          "type": "AdaptiveCard",
          "$schema": "http://adaptivecards.io/schemas/adaptive-card.json",
          "version": "1.5",
          "refresh": {
            "action": {
              "type": "Action.Execute",
              "title": "Refresh",
              "verb": "test"
            }
          },
          "body": [
            {
              "type": "TextBlock",
              "text": "⚙️ Settings",
              "weight": "bolder",
              "wrap": true
            },
            {
              "id": "apiKey",
              "type": "Input.Text",
              "value": "${title}",
              "label": "API Key",
              "isRequired": true,
              "errorMessage": "Please enter your API Key",
              "style": "password"
            },
            {
              "type": "ActionSet",
              "actions": [
                {
                  "type": "Action.OpenUrl",
                  "title": "Get API Key",
                  "url": "https://beta.openai.com/account/api-keys"
                }
              ]
            },
            {
              "id": "n",
              "type": "Input.Number",
              "min": 1,
              "max": 10,
              "isRequired": true,
              "label": "Results (1-10)",
              "errorMessage": "Please enter a number between 1 and 10"
            },
            {
              "id": "size",
              "type": "Input.ChoiceSet",
              "label": "Image size",
              "style": "expanded",
              "choices": [
                {
                  "title": "1024x1024",
                  "value": "1024x1024"
                },
                {
                  "title": "512x512",
                  "value": "512x512"
                },
                {
                  "title": "256x256",
                  "value": "256x256"
                }
              ]
            },
            {
              "type": "ActionSet",
              "actions": [
                {
                  "type": "Action.Execute",
                  "title": "Save",
                  "verb": "test",
                  "data": {}
                },
                {
                  "type": "Action.Execute",
                  "title": "Cancel",
                  "verb": "test"
                }
              ]
            }
          ]
        }
        """;

    public IMessageActivity CreateActivity(TestInput input)
    {
        var cardContent = new AdaptiveCardTemplate(Template).Expand(input);

        return MessageFactory.Attachment
        (
            new Attachment
            {
                ContentType = "application/vnd.microsoft.card.adaptive",
                Content = JsonConvert.DeserializeObject(cardContent),
            }
        );
    }
}

public class TestInput
{
    public string Title { get; set; }
}
