using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccess
{
    public class clsEventLog:EventLog
    {

        public static string SourceName = "DVLD";

        public enum enType { Application = 1, Security = 2, Setup = 3, System = 4, ForwardedEvent = 5 }

        static string _SelectType(enType Type)
        {
            switch (Type)
            {
                case enType.Application:
                    return "Applicaton";
                case enType.Security:
                    return "Security";
                case enType.Setup:
                    return "Setup";
                case enType.System:
                    return "System";
                case enType.ForwardedEvent:
                    return "Forwarded Event";
                default:
                    return "";
            }
        }


        public static void EventLogException(Exception ex, enType Location, EventLogEntryType Type)
        {

            _SelectType(Location);

            if (!Exists(SourceName))
            {
                CreateEventSource(SourceName, _SelectType(Location));
            }

            WriteEntry(SourceName, ex.ToString(), Type);



        }

        public static void WriteEvent(string EventLogName, Exception ex, enType Location, EventLogEntryType Type)
        {

            _SelectType(Location);

            if (!SourceExists(SourceName))
            {
                CreateEventSource(SourceName, _SelectType(Location));
            }

            WriteEntry(SourceName, ex.ToString(), Type);



        }



    }
}
