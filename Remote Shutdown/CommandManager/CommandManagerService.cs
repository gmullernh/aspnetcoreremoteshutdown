using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Remote_Shutdown.CommandManager
{
    public class CommandManagerService
    {
        public List<ICommand> CommandList { get; set; }

        public CommandManagerService()
        {
            // Initializes the command list
            CommandList = new List<ICommand>()
            {
                new Commands.ShutdownCommand(),
                new Commands.RestartCommand(),
                new Commands.LogOffCommand(),
                new Commands.LockWorkstationCommand(),
                new Commands.HibernateCommand(),
                new Commands.SleepCommand()
            };
        }

        // Executes a command based on the name
        public string ExecuteCommandByName(string commandName)
        {
            try
            {
                CommandList.FirstOrDefault(s => s.Name == commandName).Execute();
                return $"Command successfully executed: ${commandName}";
            }
            catch (AggregateException e)
            {
                return $"Error when executing the command {commandName}: {e.Message}";
            }
        }
    }

}
