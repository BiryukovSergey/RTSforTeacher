using System.Collections.Generic;
using Abstractions;
using Abstractions.Commands;
using UnityEngine;
using UserControlSystem.UI.View;
using Zenject;

namespace UserControlSystem.UI.Presenter
{
    public sealed class CommandButtonsPresenter : MonoBehaviour
    {
        [SerializeField] private SelectableValue _selectable;
        [SerializeField] private CommandButtonsView _view;
        
        [Inject] private CommandButtonsModel _model;
        
        private ISelecatable _currentSelecatable;


        private void Start()
        {
            _view.OnClick += _model.OnCommandButtonClicked;
            _model.OnCommandSent += _view.UnblockAllInteractions;
            _model.OnCommandCancel += _view.UnblockAllInteractions;
            _model.OnCommandAccepted += _view.BlockInteractions;
            _selectable.OnNewValue += onSelected;
            onSelected(_selectable.CurrentValue);

        }
        
        private void onSelected(ISelecatable selectable)
        {
            if (_currentSelecatable == selectable)
            {
                return;
            }
            if (_currentSelecatable != null)
            {
                _model.OnSelectionChanged();
            }
            _currentSelecatable = selectable;
            
            _view.Clear();
            
            if (selectable != null)
            {
                var commandExecutors = new List<ICommandExecutor>();
                commandExecutors.AddRange((selectable as Component).GetComponentsInParent<ICommandExecutor>());
                _view.MakeLayout(commandExecutors);
            }
        }
/*
        private void ONButtonClick(ICommandExecutor commandExecutor)
        {
            var unitProducer = commandExecutor as CommandExecutorBase<IProduceUnitCommand>;
            if (unitProducer != null)
            {
                unitProducer.ExecuteSpecificCommand(_context.Inject(new ProduceUnitCommandHeir()));
                return;
            }
            var attackCommand = commandExecutor as CommandExecutorBase<IAttackCommand>;
            if (attackCommand != null)
            {
                attackCommand.ExecuteSpecificCommand(_context.Inject(new AttackCommand()));
                return;
            }
            var moveCommand = commandExecutor as CommandExecutorBase<IMoveCommand>;
            if (moveCommand != null)
            {
                moveCommand.ExecuteSpecificCommand(_context.Inject(new MoveCommand()));
                return;
            }
            var stopCommand = commandExecutor as CommandExecutorBase<IStopCommand>;
            if (stopCommand != null)
            {
                stopCommand.ExecuteSpecificCommand(_context.Inject(new StopCommand()));
                return;
            }
            var patrolCommand = commandExecutor as CommandExecutorBase<IPatrolCommand>;
            if (patrolCommand != null)
            {
                patrolCommand.ExecuteSpecificCommand(_context.Inject(new PatrolCommand()));
                return;
            }
            throw new ApplicationException($"{nameof(CommandButtonsPresenter)}.{nameof(ONButtonClick)}: " +
                                           $"Unknown type of commands executor: {commandExecutor.GetType().FullName}!");
        }*/
    }
}