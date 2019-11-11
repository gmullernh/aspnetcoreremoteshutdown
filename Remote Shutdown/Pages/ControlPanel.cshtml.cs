using System;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Remote_Shutdown.Pages
{
    public class ControlPanelModel : PageModel
    {
        // Commands service
        public CommandManager.CommandManagerService CommandManagerService = new CommandManager.CommandManagerService();
        // Shutdown service
        public Services.ScheduledShutdownService ScheduledShutdownServiceInstance;
        public string Result = string.Empty;
        public DateTime Scheduling => ScheduledShutdownServiceInstance.ShutdownScheduling;

        public ControlPanelModel()
        {
            ScheduledShutdownServiceInstance = Services.ScheduledShutdownService.Instance;
        }

        public void OnGet() { }

        // Executes a command
        public void OnPostCommandSent(string command)
        {
            Result = CommandManagerService.ExecuteCommandByName(command);
        }

        // Schedules the shutdown
        public void OnPostScheduleShutdown(string hour, string minute)
        {
            ScheduledShutdownServiceInstance.ScheduleShutdown(hour, minute);
        }

        // Unschedules the shutdown
        public void OnPostUnscheduleShutdown()
        {
            ScheduledShutdownServiceInstance.UnscheduleShutdown();
        }
    }
}