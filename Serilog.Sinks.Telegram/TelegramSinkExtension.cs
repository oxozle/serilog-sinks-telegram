using System;
using Serilog.Configuration;
using Serilog.Events;

namespace Serilog.Sinks.Telegram
{
    public static class TelegramSinkExtension
    {
        public static LoggerConfiguration Telegram(
            this LoggerSinkConfiguration loggerConfiguration,
            string token,
            string chatId,
            TelegramSink.RenderMessageMethod renderMessageImplementation = null,
            LogEventLevel restrictedToMinimumLevel = LevelAlias.Minimum,
            IFormatProvider formatProvider = null
        )
        {
            if (loggerConfiguration == null)
                throw new ArgumentNullException(paramName: nameof(loggerConfiguration));

            return loggerConfiguration.Sink(
                logEventSink: new TelegramSink(
                    chatId: chatId,
                    token: token,
                    renderMessageImplementation: renderMessageImplementation,
                    formatProvider: formatProvider
                ),
                restrictedToMinimumLevel: restrictedToMinimumLevel);
        }
    }
}