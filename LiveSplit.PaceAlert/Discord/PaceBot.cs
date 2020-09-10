using System.Threading.Tasks;
using Discord.Webhook;

namespace LiveSplit.PaceAlert.Discord
{
    public class PaceBot
    {
        private DiscordWebhookClient _client;
        
        public async Task MainAsync(string webhookURL)
        {
            _client = new DiscordWebhookClient(webhookURL);
            await _client.SendMessageAsync("Hello World! (From LiveSplit)");

            await Task.Delay(-1);
        }
    }
}