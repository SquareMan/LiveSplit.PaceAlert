using System.Reflection;
using Discord;
using Discord.Webhook;

namespace LiveSplit.PaceAlert.Discord
{
    public static class PaceBot
    {
        public static bool IsConnected { get; private set; }
        public static string Name = string.Empty;
        
        private static DiscordWebhookClient _client;
        
        public static bool Connect(string webhookURL)
        {
            try
            {
                _client?.Dispose();
                _client = new DiscordWebhookClient(webhookURL);
                
                // Webhook Client's internal IWebhook field isn't exposed in Discord.NET so we do this to get the name
                if (_client.GetType().GetField("Webhook", BindingFlags.Instance | BindingFlags.NonPublic)?
                    .GetValue(_client) is IWebhook webhook)
                {
                    Name = webhook.Name;
                }
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