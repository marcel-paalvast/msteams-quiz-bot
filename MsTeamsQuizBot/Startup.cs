using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.Integration.AspNet.Core;
using Microsoft.Bot.Builder.Teams;
using Microsoft.Bot.Connector.Authentication;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.TeamsFx.Conversation;
using MsTeamsQuizBot.Actions;
using MsTeamsQuizBot.CardActions;
using MsTeamsQuizBot.Cards;
using MsTeamsQuizBot.Commands;
using MsTeamsQuizBot.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[assembly: FunctionsStartup(typeof(MsTeamsQuizBot.Startup))]
namespace MsTeamsQuizBot;

public class Startup : FunctionsStartup
{
    public override void Configure(IFunctionsHostBuilder builder)
    {
        var configuration = builder.GetContext().Configuration;

        // Create the Bot Framework Authentication to be used with the Bot Adapter.
        builder.Services.AddSingleton<BotFrameworkAuthentication, ConfigurationBotFrameworkAuthentication>();

        // Create the Cloud Adapter with error handling enabled.
        // Note: some classes expect a BotAdapter and some expect a BotFrameworkHttpAdapter, so
        // register the same adapter instance for all types.
        builder.Services.AddSingleton<CloudAdapter, AdapterWithErrorHandler>();
        builder.Services.AddSingleton<IBotFrameworkHttpAdapter>(sp => sp.GetService<CloudAdapter>());
        builder.Services.AddSingleton<BotAdapter>(sp => sp.GetService<CloudAdapter>());

        // Create the Conversation with notification feature enabled.
        builder.Services.AddSingleton(sp =>
        {
            var questionService = sp.GetService<IQuestionService>();
            var stateService = sp.GetService<IStateService>();
            var options = new ConversationOptions()
            {
                Adapter = sp.GetService<CloudAdapter>(),
                Command = new()
                {
                    Commands = new ITeamsCommandHandler[] 
                    { 
                        new HelloCommand(),
                        new CardCommand(),
                        new StartCommand(),
                    },
                },
                CardAction = new()
                {
                    Actions = new IAdaptiveCardActionHandler[] 
                    { 
                        new InitAction(),
                        new QuizAction(questionService, stateService),
                        new ForwardInstigatorAction(),
                        new AnswerAction(stateService),
                        new AnswerInistigatorAction( stateService),
                        new NextAction(questionService, stateService),
                        new StopAction(stateService),
                    },
                },
                //Notification = new NotificationOptions
                //{
                //    BotAppId = configuration["MicrosoftAppId"],
                //},
            };

            return new ConversationBot(options);
        });

        // Create the bot as a transient. In this case the ASP Controller is expecting an IBot.
        builder.Services.AddTransient<IBot, TeamsActivityHandler>();

        builder.Services.AddSingleton<IQuestionService, ExampleQuestionService>();
        builder.Services.AddSingleton<ExampleStateService>();
        builder.Services.AddSingleton<IStateService>(sp => new MemoryCacheStateService<ExampleStateService>(sp.GetService<ExampleStateService>()));
    }
}