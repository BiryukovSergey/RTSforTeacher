using System.Threading.Tasks;
using Abstractions.Commands;
using Abstractions.Commands.CommandsInterfaces;
using UnityEngine;

namespace Code.Core
{
    public class StopCommand : CommandExecutorBase<IStopCommand>,IStopCommand
    {
        public override async Task ExecuteSpecificCommand(IStopCommand command)
        {
            Debug.Log("Stop");
        }
    }
}