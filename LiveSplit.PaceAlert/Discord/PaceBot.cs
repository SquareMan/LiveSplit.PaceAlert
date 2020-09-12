using Discord.Webhook;

namespace LiveSplit.PaceAlert.Discord
{
    public static class PaceBot
    {
        private static DiscordWebhookClient _client;
        
        public static bool SetURL(string webhookURL)
        {
            try
            {
                _client?.Dispose();
                _client = new DiscordWebhookClient(webhookURL);
            }
            catch
            {
                return false;
            }

            return true;
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