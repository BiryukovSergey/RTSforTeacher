using Abstractions.Commands;
using Abstractions.Commands.CommandsInterfaces;


namespace Code.Core.CommandExecutors
{
    public class AttackCommandExecutor : CommandExecutorBase<IAttackCommand>
    {
        public override void ExecuteSpecificCommand(IAttackCommand command)
        {
            
        }
    }

}