namespace Serilog.Sinks.Telegram
{
    public sealed class TelegramMessage
    {
        public TelegramMessage(string text)
        {
            Text = text;
        }

        public string Text { get; }
    }
}