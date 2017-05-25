using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Serilog.Sinks.Telegram
{
    public class TelegramClient
    {
        private readonly Uri _apiUrl;
        private readonly HttpClient _httpClient = new HttpClient();

        public TelegramClient(string botToken, int timeoutSeconds = 10)
        {
            if (string.IsNullOrEmpty(value: botToken))
                throw new ArgumentException(message: "Bot token can't be empty", paramName: nameof(botToken));

            _apiUrl = new Uri(uriString: $"https://api.telegram.org/bot{botToken}/sendMessage");
            _httpClient.Timeout = TimeSpan.FromSeconds(value: timeoutSeconds);
        }

        public async Task<HttpResponseMessage> PostAsync(TelegramMessage message, string chatId)
        {
            var payload = new
            {
                chat_id = chatId,
                text = message.Text,
                parse_mode = "markdown"
            };
            var json = JsonConvert.SerializeObject(value: payload);
            var response = await _httpClient.PostAsync(requestUri: _apiUrl,
                content: new StringContent(content: json, encoding: Encoding.UTF8, mediaType: "application/json"));

            return response;
        }
    }
}