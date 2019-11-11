using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Remote_Shutdown.CommandManager
{
    /// <summary>
    /// Interface for commands to be implemented
    /// </summary>
    public interface ICommand
    {
        // Must be unique
        string Name { get; }
        void Execute();
    }
}
