using Abstractions.Commands.CommandsInterfaces;
using Code.Core;
using Code.UserControlSystem.UI.Model.CommandCreators;
using UnityEngine;

namespace UserControlSystem.CommandsRealization
{
    public class MoveCommandCommandCreator : CancellableCommandCreatorBase<IMoveCommand, Vector3>
    {
        protected override IMoveCommand createCommand(Vector3 argument) => new MoveCommand(argument);
    }
}