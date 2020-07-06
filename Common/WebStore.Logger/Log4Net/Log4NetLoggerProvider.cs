using Microsoft.Extensions.Logging;

using System.Collections.Concurrent;
using System.Xml;

namespace WebStore.Logger.Log4Net
{
    public class Log4NetLoggerProvider : ILoggerProvider
    {
        private readonly string configurationFile;
        private readonly ConcurrentDictionary<string, Log4NetLogger> loggers = new ConcurrentDictionary<string, Log4NetLogger>();

        public Log4NetLoggerProvider(string configurationFile) => this.configurationFile = configurationFile;

        public ILogger CreateLogger(string categoryName) =>
            loggers.GetOrAdd(categoryName, category =>
            {
                var xml = new XmlDocument();
                xml.Load(configurationFile);
                return new Log4NetLogger(category, xml["log4net"]);
            });

        public void Dispose() => loggers.Clear();
    }
}