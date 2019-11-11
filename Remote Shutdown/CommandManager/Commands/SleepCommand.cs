using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace Remote_Shutdown.CommandManager.Commands
{
    public class SleepCommand : ICommand
    {
        public string Name => "Sleep";

        [DllImport("PowrProf.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern bool SetSuspendState(bool hiberate, bool forceCritical, bool disableWakeEvent);

        public void Execute()
        {
            SetSuspendState(false, true, true);
        }
    }
}
