using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace Remote_Shutdown.CommandManager.Commands
{
    public class LockWorkstationCommand : ICommand
    {
        public string Name => "Lock Workstation";

        [DllImport("user32")]
        public static extern void LockWorkStation();

        public void Execute()
        {
            LockWorkStation();
        }
    }
}
