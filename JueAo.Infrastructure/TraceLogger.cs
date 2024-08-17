using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JueAo.Infrastructure
{
    public class TraceLogger : ILogger
    {
        public TraceLogger()
        { 
        }

        public TraceLogger(ILogger logger)
        {

        }


        public IDisposable? BeginScope<TState>(TState state) where TState : notnull
        {
            return null;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return true;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
        {
            Trace.WriteLine(formatter(state, exception));
        }
    }
}
