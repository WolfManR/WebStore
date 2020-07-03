using Microsoft.Extensions.Logging;

using System;
using System.IO;
using System.Reflection;

namespace WebStore.Logger.Log4Net
{
    public static class Log4NetExtensions
    {
        public static ILoggerFactory AddLog4Net(this ILoggerFactory factory, string configurationFile = "log4net.config")
        {
            if (!Path.IsPathRooted(configurationFile))
            {
                var assembly = Assembly.GetEntryAssembly() ?? throw new InvalidOperationException("The assembly with the entry point to the application is not defined");
                var dir = Path.GetDirectoryName(assembly.Location) ?? throw new InvalidOperationException("Failed to determine the path to the executive assembly directory");
                configurationFile = Path.Combine(dir, configurationFile);
            }

            factory.AddProvider(new Log4NetLoggerProvider(configurationFile));

            return factory;
        }
    }
}