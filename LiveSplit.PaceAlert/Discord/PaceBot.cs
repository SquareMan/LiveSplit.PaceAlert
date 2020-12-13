using System.Collections.Generic;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Discord;
using Discord.Webhook;
using LiveSplit.PaceAlert.UI;

namespace LiveSplit.PaceAlert.Discord
{
    public static class PaceBot
    {
        public static string Name = string.Empty;

        private static DiscordWebhookClient _client;
        public static bool IsConnected { get; private set; }

        public static bool Connect(string webhookURL)
        {
            try
            {
                _client?.Dispose();
                _client = new DiscordWebhookClient(webhookURL);

                // Webhook Client's internal IWebhook field isn't exposed in Discord.NET so we do this to get the name
                if (_client.GetType().GetField("Webhook", BindingFlags.Instance | BindingFlags.NonPublic)?
                    .GetValue(_client) is IWebhook webhook)
                    Name = webhook.Name;
                IsConnected = true;
            }
            catch
            {
                IsConnected = false;
            }

            return IsConnected;
        }

        public static async void SendMessage(string text, int delay, CancellationToken cancellationToken)
        {
            SendMessage(text, null, delay, cancellationToken);
        }
        
        public static async void SendMessage(string text, string filepath, int delay, CancellationToken cancellationToken)
        {
            try
            {
                await Task.Delay(delay, cancellationToken);
            }
            catch (TaskCanceledException e)
            {
                return;
            }

            if (!cancellationToken.IsCancellationRequested)
            {
                SendMessage(text, filepath);
            }
        }

        public static async void SendMessage(string text, string filepath)
        {
            try
            {
                if (string.IsNullOrEmpty(filepath))
                {
                    await _client.SendMessageAsync(text);
                }
                else
                {
                    await _client.SendFileAsync(filepath, text);
                }
            }
            catch
            {
            }
        }
    }
}