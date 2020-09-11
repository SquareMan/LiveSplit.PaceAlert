using Discord.Webhook;

namespace LiveSplit.PaceAlert.Discord
{
    public static class PaceBot
    {
        private static DiscordWebhookClient _client;
        
        public static async void SetURL(string webhookURL)
        {
            try
            {
                _client?.Dispose();
                _client = new DiscordWebhookClient(webhookURL);
            }
            catch {}
        }
        
        public static async void SendMessage(string text)
        {
            try
            {
                await _client.SendMessageAsync(text);
            }
            catch {}
        }
    }
}