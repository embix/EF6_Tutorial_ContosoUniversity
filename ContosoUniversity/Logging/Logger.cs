using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Web;

namespace ContosoUniversity.Logging
{
    public class Logger : ILogger
    {
        public void Information(String message)
        {
            Trace.TraceInformation(message);
        }

        public void Information(String fmt, params Object[] vars)
        {
            Trace.TraceInformation(fmt, vars);
        }

        public void Information(Exception exception, String fmt, params Object[] vars)
        {
            Trace.TraceInformation(FormatExceptionMessage(exception, fmt, vars));
        }

        public void Warning(String message)
        {
            Trace.TraceWarning(message);
        }

        public void Warning(String fmt, params Object[] vars)
        {
            Trace.TraceWarning(fmt, vars);
        }

        public void Warning(Exception exception, String fmt, params Object[] vars)
        {
            Trace.TraceWarning(FormatExceptionMessage(exception, fmt, vars));
        }

        public void Error(String message)
        {
            Trace.TraceError(message);
        }

        public void Error(String fmt, params Object[] vars)
        {
            Trace.TraceError(fmt, vars);
        }

        public void Error(Exception exception, String fmt, params Object[] vars)
        {
            Trace.TraceError(FormatExceptionMessage(exception, fmt, vars));
        }

        public void TraceApi(String componentName, String method, TimeSpan timespan)
        {
            TraceApi(componentName, method, timespan, "");
        }

        public void TraceApi(String componentName, String method, TimeSpan timespan, String fmt, params Object[] vars)
        {
            TraceApi(componentName, method, timespan, String.Format(fmt, vars));
        }

        public void TraceApi(String componentName, String method, TimeSpan timespan, String properties)
        {
            String message = String.Concat(
                "Component:", componentName, 
                ";Method:", method, 
                ";Timespan:", timespan.ToString(), 
                ";Properties:", properties
            );
            Trace.TraceInformation(message);
        }

        private static string FormatExceptionMessage(Exception exception, String fmt, Object[] vars)
        {
            // Simple exception formatting: for a more comprehensive version see  
            // http://code.msdn.microsoft.com/windowsazure/Fix-It-app-for-Building-cdd80df4 
            var sb = new StringBuilder();
            sb.Append(String.Format(fmt, vars));
            sb.Append(" Exception: ");
            sb.Append(exception.ToString());
            return sb.ToString();
        }
    }
}