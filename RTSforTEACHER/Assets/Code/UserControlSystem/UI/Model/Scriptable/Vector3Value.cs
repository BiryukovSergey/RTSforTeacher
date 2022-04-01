using System;
using Abstractions.Commands.CommandsInterfaces;
using UnityEngine;

namespace UserControlSystem
{
    [CreateAssetMenu(fileName = nameof(Vector3Value), menuName = "Strategy Game/" + nameof(Vector3Value), order = 0)]
    public class Vector3Value : ScriptableObjectValueBase<IMoveCommand>
    {
        public Vector3 CurrentValue { get; private set; }
        public Action<Vector3> OnNewValue;

        public void SetValue(Vector3 value)
        {
            CurrentValue = value;
            OnNewValue?.Invoke(value);
        }
    }
}