using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XileConsole.Events
{
    public class OnNewMapEnterEvent : EventArgs
    {
        public MapInfo mi;

        public OnNewMapEnterEvent(MapInfo mi)
        {
            this.mi = mi;
        }
    }

    public class OnEnterHideoutEvent : EventArgs
    {

    }

    public class OnEnterMapEvent : EventArgs
    {
        public MapInfo mapInfo;

        public OnEnterMapEvent(MapInfo mapInfo)
        {
            this.mapInfo = mapInfo;
        }
    }

    public class OnMapFinishedEvent : EventArgs
    {
        public MapInfo mapInfo;

        public OnMapFinishedEvent(MapInfo mapInfo)
        {
            this.mapInfo = mapInfo;
        }
    }

    public class TrackerUpdateEvent : EventArgs
    {

    }

    public class ResetTrackerEvent : EventArgs
    {

    }
}
