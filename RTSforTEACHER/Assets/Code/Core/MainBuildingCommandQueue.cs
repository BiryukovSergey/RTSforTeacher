using Abstractions;
using Abstractions.Commands;
using Abstractions.Commands.CommandsInterfaces;
using UnityEngine;
using Zenject;

namespace Code.Core
{
    public class MainBuildingCommandQueue : MonoBehaviour, ICommandsQueue
    {
        [Inject] CommandExecutorBase<IProduceUnitCommand> _produceUnitCommandExecutor;
        [Inject] CommandExecutorBase<ISetRallyPointCommand> _setRally;
            
        public void Clear() { }
        public async void EnqueueCommand(object command)
        {
            await _produceUnitCommandExecutor.TryExecuteCommand(command);
        }

    }
}