using Abstractions.Commands;
using Abstractions.Commands.CommandsInterfaces;
using UnityEngine;

namespace Code.Core
{
    public class StopCommand : CommandExecutorBase<IStopCommand>,IStopCommand
    {
        public override void ExecuteSpecificCommand(IStopCommand command)
        {
            Debug.Log("Stop");
        }
    }
}