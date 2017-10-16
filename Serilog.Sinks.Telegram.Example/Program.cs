using System;

namespace Serilog.Sinks.Telegram.Example
{
    class Program
    {
        static void Main(string[] args)
        {

            var log = new LoggerConfiguration()
                .MinimumLevel.Verbose()
                .WriteTo.Telegram("363800287:AAFZe7kmqPcyipNS7kzU4dYdCl3GabU7NaE", "110502278")
                .CreateLogger();

            try
            {
                log.Verbose("This is an verbose message!");
                log.Debug("This is an debug message!");
                log.Information("This is an information message!");
                log.Warning("This is an warning message!");
                log.Error("This is an error message!");
                throw new Exception("This is an exception!");
            }
            catch (Exception exception)
            {
                log.Fatal(exception, "Exception catched at Main.");
            }
        }
    }
}