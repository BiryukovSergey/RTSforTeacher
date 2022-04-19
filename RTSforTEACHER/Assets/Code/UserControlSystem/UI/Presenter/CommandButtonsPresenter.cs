﻿using System;
using System.Collections.Generic;
using Abstractions;
using Abstractions.Commands;
using UnityEngine;
using UserControlSystem.UI.View;
using Code.UserControlSystem.UI;
using Zenject;
using UniRx;

namespace UserControlSystem.UI.Presenter
{
    public class CommandButtonsPresenter : MonoBehaviour
    {
        [SerializeField] private CommandButtonsView _view;
        
        [Inject] private IObservable<ISelectable> _selectedValues;
        [Inject] private CommandButtonsModel _model;
        
        private ISelectable _currentSelectable;

        private void Start()
        {
            _view.OnClick += _model.OnCommandButtonClicked;
            _model.OnCommandSent += _view.UnblockAllInteractions;
            _model.OnCommandCancel += _view.UnblockAllInteractions;
            _model.OnCommandAccepted += _view.BlockInteractions;
            
            _selectedValues.Subscribe(onSelected);

        }
        private void onSelected(ISelectable selectable)
        {
            if (_currentSelectable == selectable)
            {
                return;
            }
            if (_currentSelectable != null)
            {
                _model.OnSelectionChanged();
            }
            _currentSelectable = selectable;
            _view.Clear();
            if (selectable != null)
            {
                var commandExecutors = new List<ICommandExecutor>();
                commandExecutors.AddRange((selectable as Component).GetComponentsInParent<ICommandExecutor>());
                var queue = (selectable as Component).GetComponentInParent<ICommandsQueue>();
                _view.MakeLayout(commandExecutors, queue);
            }
        }
    }
}