using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Remote_Shutdown.CommandManager.Commands
{
    public class RestartCommand : ICommand
    {
        public string Name => "Restart";

        public void Execute()
        {
            Process.Start("shutdown", "/r /t 0");
        }
    }
}
