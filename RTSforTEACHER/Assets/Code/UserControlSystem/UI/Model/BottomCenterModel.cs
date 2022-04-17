﻿using System;
using Abstractions;
using UniRx;
using UnityEngine;
using Zenject;
using ISelectable = Abstractions.ISelectable;

namespace Code.UserControlSystem.UI.Model
{
    public class BottomCenterModel
    {
        public IObservable<IUnitProducer> UnitProducers { get; private set; }

        [Inject]
        public void Init(IObservable<ISelectable> currentlySelected)
        {
            UnitProducers = currentlySelected.Select(selectable => selectable as Component)
                .Select(component => component?.GetComponent<IUnitProducer>());
        }
    }
}