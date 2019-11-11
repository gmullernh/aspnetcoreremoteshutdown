using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace Remote_Shutdown.CommandManager.Commands
{
    public class HibernateCommand : ICommand
    {
        public string Name => "Hibernate";

        [DllImport("PowrProf.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern bool SetSuspendState(bool hiberate, bool forceCritical, bool disableWakeEvent);

        public void Execute()
        {
            SetSuspendState(true, true, true);
        }
    }
}
