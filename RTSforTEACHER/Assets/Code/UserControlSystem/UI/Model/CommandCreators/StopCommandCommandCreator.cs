using System;
using Abstractions.Commands.CommandsInterfaces;
using UserControlSystem.CommandCreators;

namespace UserControlSystem.CommandsRealization
{
    public class StopCommandCommandCreator : CommandCreatorBase<IStopCommand>
    {
        protected override void classSpecificCommandCreation(Action<IStopCommand> creationCallback)
        {
            
        }
    }
}