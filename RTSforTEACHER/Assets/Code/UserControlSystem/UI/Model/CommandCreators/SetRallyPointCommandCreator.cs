using Abstractions;
using Code.UserControlSystem.UI.Model.CommandCreators;
using UnityEngine;

namespace Code.Core.CommandExecutors
{
    public class SetRallyPointCommandCreator : CancellableCommandCreatorBase<ISetRallyPointCommand, Vector3>
    {
        protected override ISetRallyPointCommand createCommand(Vector3 argument) =>
            new SetRallyPointCommand(argument);
    }
}