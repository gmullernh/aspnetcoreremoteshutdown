using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Remote_Shutdown.CommandManager.Commands
{
    public class ShutdownCommand : ICommand
    {
        public string Name => "Shutdown";

        public void Execute()
        {
            Process.Start("shutdown", "/s /t 0");
        }
    }
}
