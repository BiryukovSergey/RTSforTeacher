using System.Threading.Tasks;
using Abstractions.Commands;
using Abstractions.Commands.CommandsInterfaces;


namespace Code.Core.CommandExecutors
{
    public class AttackCommandExecutor : CommandExecutorBase<IAttackCommand>
    {
        public override async Task ExecuteSpecificCommand(IAttackCommand command)
        {
            
        }
    }

}