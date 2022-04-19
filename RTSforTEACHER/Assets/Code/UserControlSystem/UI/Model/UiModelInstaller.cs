using Abstractions;
using Abstractions.Commands.CommandsInterfaces;
using Code.Core.CommandExecutors;
using Code.UserControlSystem.UI;
using Code.UserControlSystem.UI.Model;
using UnityEngine;
using UserControlSystem.CommandCreators;
using UserControlSystem.CommandsRealization;
using Zenject;

namespace UserControlSystem
{
    public class UiModelInstaller : MonoInstaller
    {
        [SerializeField] private Sprite _chomperSprite;
        public override void InstallBindings()
        {
            Container.Bind<CommandCreatorBase<IProduceUnitCommand>>().To<ProduceUnitCommandCommandCreator>().AsTransient();
            Container.Bind<CommandCreatorBase<IAttackCommand>>().To<AttackCommandCommandCreator>().AsTransient();
            Container.Bind<CommandCreatorBase<IMoveCommand>>().To<MoveCommandCommandCreator>().AsTransient();
            Container.Bind<CommandCreatorBase<IPatrolCommand>>().To<PatrolCommandCommandCreator>().AsTransient();
            Container.Bind<CommandCreatorBase<IStopCommand>>().To<StopCommandCommandCreator>().AsTransient();
            Container.Bind<CommandCreatorBase<ISetRallyPointCommand>>().To<SetRallyPointCommandCreator>().AsTransient();

            Container.Bind<CommandButtonsModel>().AsTransient();
            
            Container.Bind<float>().WithId("Chomper123").FromInstance(5f);
            Container.Bind<string>().WithId("Chomper123").FromInstance("Chomper123");
            Container.Bind<Sprite>().WithId("Chomper123").FromInstance(_chomperSprite);
            
            Container.Bind<BottomCenterModel>().AsSingle ();
        }
    }
}