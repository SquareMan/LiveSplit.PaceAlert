using Discord.Webhook;

namespace LiveSplit.PaceAlert.Discord
{
    public static class PaceBot
    {
        public static bool IsConnected { get; private set; }
        
        private static DiscordWebhookClient _client;
        
        public static bool Connect(string webhookURL)
        {
            try
            {
                _client?.Dispose();
                _client = new DiscordWebhookClient(webhookURL);
                IsConnected = true;
            }
            catch
            {
                IsConnected = false;
            }

            return IsConnected;
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