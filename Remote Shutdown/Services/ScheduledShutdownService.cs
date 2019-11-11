using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Remote_Shutdown.Services
{
    public class ScheduledShutdownService
    {
        // Creates a singleton
        static ScheduledShutdownService _instance;
        public static ScheduledShutdownService Instance
        {
            get { return _instance ?? (_instance = new ScheduledShutdownService()); }
        }

        public DateTime ShutdownScheduling { get; set; }

        public ScheduledShutdownService()
        {
            // Resets the scheduled time on startup
            ShutdownScheduling = DateTime.Now.AddDays(999);
            Start();
        }

        public void Start(int timeBetweenRequests = 60 * 1000)
        {
            new Task(async () => {
                while (true)
                {
                    // Executes a HTTP Request to the KeepAlive Endpoint to keep the application running
                    KeepAliveHelper.KeepAlive();

                    DateTime fromTimeServer = TimeServiceHelper.GetDateTimeSPFromRemote();

                    // If the time at the remote server is later than the scheduled time.
                    if (DateTime.Compare(fromTimeServer, ShutdownScheduling) > 0)
                    {
                        // Shutdown command 
                        CommandManager.Commands.ShutdownCommand s = new CommandManager.Commands.ShutdownCommand();
                        s.Execute();
                    }
                    Console.WriteLine($"Fetched remote time {fromTimeServer.ToLocalTime()}");

                    await Task.Delay(timeBetweenRequests);
                }
            }).Start();
        }

        public void ScheduleShutdown(string hour, string minute)
        {
            DateTime remoteTime = TimeServiceHelper.GetDateTimeSPFromRemote();

            if (int.Parse(hour) > remoteTime.Hour)
            {
                // Schedule for today
                DateTime tempTime = remoteTime;
                string timeToShutdown = $"{tempTime.Year}/{tempTime.Month}/{tempTime.Day} {hour}:{minute}";
                ShutdownScheduling = Convert.ToDateTime(timeToShutdown);
            }
            else if (int.Parse(hour) == remoteTime.Hour)
            {
                if (int.Parse(minute) > remoteTime.Minute)
                {
                    // Schedule for today
                    DateTime tempTime = remoteTime;
                    string timeToShutdown = $"{tempTime.Year}/{tempTime.Month}/{tempTime.Day} {hour}:{minute}";
                    ShutdownScheduling = Convert.ToDateTime(timeToShutdown);
                }
                else
                {
                    // Schedule for tomorrow
                    DateTime tempTime = remoteTime.AddDays(1);
                    string timeToShutdown = $"{tempTime.Year}/{tempTime.Month}/{tempTime.Day} {hour}:{minute}";
                    ShutdownScheduling = Convert.ToDateTime(timeToShutdown);
                }
            }
            else
            {
                // Schedule for tomorrow
                DateTime tempTime = remoteTime.AddDays(1);
                string timeToShutdown = $"{tempTime.Year}/{tempTime.Month}/{tempTime.Day} {hour}:{minute}";
                ShutdownScheduling = Convert.ToDateTime(timeToShutdown);
            }
        }

        public void UnscheduleShutdown()
        {
            // Add 999 days
            ShutdownScheduling = DateTime.Now.AddDays(999);
        }

    }
}
