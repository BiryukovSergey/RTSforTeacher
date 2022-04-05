using System.Threading;
using Abstractions.Commands;
using Abstractions.Commands.CommandsInterfaces;
using UnityEngine;

namespace Code.Core.CommandExecutors
{
    public class StopCommandExecutor : CommandExecutorBase<IStopCommand>
    {
        public CancellationTokenSource CancellationTokenSource { get; set; }
        public override void ExecuteSpecificCommand(IStopCommand command)
        {
           CancellationTokenSource?.Cancel(); // команда не работает
        }
    }

}