[![Hack Together: Microsoft Graph and .NET](https://img.shields.io/badge/Microsoft-Hack--Together--Teams-6264A7?style=for-the-badge&logo=microsoft)](https://github.com/microsoft/hack-together-teams)

# MsTeams Quiz Bot

A Microsoft Teams bot to create a quiz inside any chat about any subject using randomly generated questions.

## Key Features

When mentioned with `@bot-name quiz` the bot will create an adaptive card allowing a user to setup a quiz about their specified topic and in their language. The user starting the quiz then has full control to participate and decide when to lock a question and generate the next question or to stop the quiz and show the top 10 results.

A Function App handles the messages that are received by the bot reacting to the prompts and generating responses using [Microsoft's Adapative Cards](https://adaptivecards.io/). The Function App uses a Cosmos Database to maintain its state allowing it to scale and not require it to be always on (so serverless is an option). A memory cache is maintained to quickly access objects should the Function App still be active from previous requests. Questions are generated using OpenAi's ChatGpt allowing you to 

## How to setup your own environment:

### Required Resources

1. Function App
    - Runs the api
    - Can run serverless
1. Cosmos Database
    - Maintains the state
    - Can run serverless
    - Set up a `ttl` on container level to remove old data
1. OpenAi ChatGpt
    - Generates questions based on user topic and language
1. Bot registration
    - Bot needs to be registered on the bot framework

Example of a `local.appsettings.json` required to run.
```
{
  "IsEncrypted": false,
  "Values": {
    "AzureWebJobsStorage": "UseDevelopmentStorage=true",
    "FUNCTIONS_WORKER_RUNTIME": "dotnet",
    "MicrosoftAppType": "MultiTenant",
    "MicrosoftAppId": "<bot app id>",
    "MicrosoftAppPassword": "<bot password>",
    "Cosmos:Endpoint": "<endpoint uri>",
    "Cosmos:Key": "<access key>",
    "Cosmos:Database": "<database name>",
    "Cosmos:Container": "<container name>",
    "OpenAi:ApiKey": "<api key obtained from https://platform.openai.com/account/api-keys>"
  }
}
```