using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace Remote_Shutdown.CommandManager.Commands
{
    public class LogOffCommand : ICommand
    {
        public string Name => "LogOff";

        [DllImport("user32")]
        public static extern bool ExitWindowsEx(uint uFlags, uint dwReason);

        public void Execute()
        {
            ExitWindowsEx(0, 0);
        }
    }
}
