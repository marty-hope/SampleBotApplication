using System;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using Microsoft.Bot.Builder.Luis;
using Microsoft.Bot.Builder.Luis.Models;

namespace SampleBotApplication.Dialogs
{
    [LuisModel("1b7f8e55-4e87-4c3a-8692-2e03dc97f44b", "a5de7949cfd14369876ad394fe96bfa7")]
    [Serializable]
    public class RootLuisDialog : LuisDialog<object>
    {
        [LuisIntent("")]
        [LuisIntent("None")]
        public async Task None(IDialogContext context, LuisResult result)
        {
            string message = $"Sorry, I did not understand '{result.Query}'. Type 'help' if you need assistance.";

            await context.PostAsync(message);

            context.Wait(this.MessageReceived);
        }

        [LuisIntent("Help")]
        public async Task Help(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("Hi! Try entering 'Hello', 'Hi', 'yo'");

            context.Wait(this.MessageReceived);
        }

        [LuisIntent("Hi")]
        public async Task Hello(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("Hey there!'");

            context.Wait(this.MessageReceived);
        }

    }
}