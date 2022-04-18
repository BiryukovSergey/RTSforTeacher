using System.Threading.Tasks;
using Abstractions;
using Abstractions.Commands;

namespace Code.Core.CommandExecutors
{
    public class SetRallyPointCommandExecutor  : CommandExecutorBase<ISetRallyPointCommand>

    {
        public override async Task ExecuteSpecificCommand(ISetRallyPointCommand command)
        {
            GetComponent<MainBuilding>().RallyPoint = command.RallyPoint;
        }
    }
}