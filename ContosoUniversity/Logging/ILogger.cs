using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContosoUniversity.Logging
{
    public interface ILogger
    {
        void Information(String message);
        void Information(String fmt, params Object[] vars);
        void Information(Exception exception, String fmt, params Object[] vars);

        void Warning(String message);
        void Warning(String fmt, params Object[] vars);
        void Warning(Exception exception, String fmt, params Object[] vars);

        void Error(String message);
        void Error(String fmt, params Object[] vars);
        void Error(Exception exception, String fmt, params Object[] vars);

        void TraceApi(String componentName, String method, TimeSpan timespan);
        void TraceApi(String componentName, String method, TimeSpan timespan, String properties);
        void TraceApi(String componentName, String method, TimeSpan timespan, String fmt, params Object[] vars); 
    }
}
