using Abstractions.Commands.CommandsInterfaces;
using UnityEngine;

namespace UserControlSystem.CommandsRealization
{
    public class ProduceUnitCommandHeir : ProduceUnitCommand
    {
        public GameObject UnitPrefab { get; }
    }
}