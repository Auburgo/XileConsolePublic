using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Terminal.Gui;
using XileConsole.Events;

namespace XileConsole.Misc
{
    public enum Currency
    {
        Chaos,
        Divine
    }

    public class RTTracker
    {
        private static readonly RTTracker instance = new RTTracker();
        static RTTracker() { } 
        private RTTracker() {
            timer = new System.Timers.Timer(1000);
            timer.AutoReset = true;
            timer.Elapsed += (source, e) => { Application.MainLoop.Invoke(() => { Eventbus.Instance.Publish(this, new TrackerUpdateEvent()); }); }; }

        public static RTTracker Instance { get { return instance; } }

        public List<MapInfo> mapInfos = new List<MapInfo>();
        
        public bool isRecording = false;
        Stopwatch stopwatch = new Stopwatch();

        System.Timers.Timer timer;



        public TimeSpan GetTotalTime()
        {
            return stopwatch.Elapsed;
        }


        public TimeSpan GetAverageTimePerMap()
        {
            if(mapInfos.Count == 0) return TimeSpan.Zero;
            
            int count = 0;
            TimeSpan avgTimePerMap = TimeSpan.Zero;

            foreach (var mi in mapInfos)
            {
                if (mi.timeInMap == TimeSpan.Zero)
                {
                    continue;
                }
                avgTimePerMap += mi.timeInMap;
                count++;
            }

            avgTimePerMap /= count;

            return avgTimePerMap;
        }

        public float GetAverageValuePerMap()
        {
            if(mapInfos.Count == 0) { return 0f; }

            float avgMapValue = 0;

            foreach (var mi in mapInfos)
            {
                avgMapValue += mi.inventory.Sum();
            }
            avgMapValue /= mapInfos.Count;

            return avgMapValue.Truncate(2);
        }

        public float GetCurrencyPerHour(Currency c)
        {
            if (mapInfos.Count == 0) { return 0f; }

            float totalChaosPerHour = 0;
            int count = 0;

            foreach (var mi in mapInfos)
            {
                if (mi.timeInMap == TimeSpan.Zero)
                {
                    continue;
                }
                count++;
                totalChaosPerHour += (mi.inventory.Sum() / (float)stopwatch.Elapsed.TotalHours);
            }

            totalChaosPerHour /= count;

            if(c == Currency.Chaos)
            {
                return totalChaosPerHour.Truncate(2);
            }
            else
            {
                return (totalChaosPerHour / DataHandler.Instance.inventoryHandler.inventory.divinePrice).Truncate(2);
            }
        }

        public void Start()
        {
            stopwatch.Start();
            timer.Start();
            isRecording = true;
        }

        public void Stop()
        {
            stopwatch.Stop();
            timer.Stop();
            isRecording = false;
        }

        public void Reset()
        {
            Stop();
            stopwatch.Reset();
            mapInfos.Clear();
            Eventbus.Instance.Publish(this, new ResetTrackerEvent());
        }

        public void AddMap(MapInfo mapInfo)
        {
            mapInfos.Add(mapInfo);
        }
    }
}
