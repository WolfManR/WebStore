using log4net;

using Microsoft.Extensions.Logging;

using System;
using System.Reflection;
using System.Xml;

namespace WebStore.Logger.Log4Net
{
    public class Log4NetLogger : ILogger
    {
        private readonly ILog log;

        public Log4NetLogger(string categoryName, XmlElement configuration)
        {
            var loggerRepository = LogManager.CreateRepository(
                Assembly.GetEntryAssembly(),
                typeof(log4net.Repository.Hierarchy.Hierarchy));

            log = LogManager.GetLogger(loggerRepository.Name, categoryName);

            log4net.Config.XmlConfigurator.Configure(loggerRepository, configuration);
        }

        public IDisposable BeginScope<TState>(TState state) => null;

        public bool IsEnabled(LogLevel level)
        {
            switch (level)
            {
                default: throw new ArgumentOutOfRangeException(nameof(level), level, null);
                case LogLevel.None: return false;

                case LogLevel.Trace:
                case LogLevel.Debug:
                    return log.IsDebugEnabled;

                case LogLevel.Information:
                    return log.IsInfoEnabled;

                case LogLevel.Warning:
                    return log.IsWarnEnabled;

                case LogLevel.Error:
                    return log.IsErrorEnabled;

                case LogLevel.Critical:
                    return log.IsFatalEnabled;
            }
        }

        public void Log<TState>( LogLevel level, EventId id, TState state, Exception error, Func<TState, Exception, string> formatter)
        {
            if (formatter is null)
                throw new ArgumentNullException(nameof(formatter));

            if (!IsEnabled(level)) return;

            var logMessage = formatter(state, error);

            if (string.IsNullOrEmpty(logMessage) && error is null) return;

            switch (level)
            {
                default: throw new ArgumentOutOfRangeException(nameof(level), level, null);
                case LogLevel.None: break;


                case LogLevel.Trace:
                case LogLevel.Debug:
                    log.Debug(logMessage);
                    break;

                case LogLevel.Information:
                    log.Info(logMessage);
                    break;

                case LogLevel.Warning:
                    log.Warn(logMessage);
                    break;

                case LogLevel.Error:
                    log.Error(logMessage, error);
                    break;

                case LogLevel.Critical:
                    log.Fatal(logMessage, error);
                    break;
            }
        }
    }
}