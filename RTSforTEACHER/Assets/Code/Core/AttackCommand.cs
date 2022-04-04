using Abstractions;
using Abstractions.Commands.CommandsInterfaces;

namespace Code.Core
{
    public class AttackCommand : IAttackCommand
    {
        public IAttackable Target { get; }

        public AttackCommand(IAttackable attackable)
        {
            Target = attackable;
        }
    }
}