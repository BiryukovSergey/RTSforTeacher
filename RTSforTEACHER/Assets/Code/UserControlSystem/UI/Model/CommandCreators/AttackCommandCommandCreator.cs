using Abstractions;
using Abstractions.Commands.CommandsInterfaces;
using Code.Core;
using Code.UserControlSystem.UI.Model.CommandCreators;

namespace UserControlSystem.CommandsRealization
{
    public class AttackCommandCommandCreator : CancellableCommandCreatorBase<IAttackCommand, IAttackable>

    {
        protected override IAttackCommand createCommand(IAttackable argument) => new AttackCommand(argument);

    }
}