
namespace ApiAuthViewLayer.Utils
{
    public class Logger : ILogger, IDisposable
    {
        public IDisposable? BeginScope<TState>(TState state) where TState : notnull
        {
            return this;
        }

        public void Dispose()
        {
           
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            //return logLevel.HasFlag(LogLevel.Information);
            return true;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
        {
            Console.WriteLine($"{formatter(state, exception)}; {Environment.NewLine}");
        }
    }
}
