using Abstractions.Commands.CommandsInterfaces;
using UnityEngine;
using Zenject;

namespace UserControlSystem.CommandsRealization
{
    public class ProduceUnitCommand : IProduceUnitCommand
    {
        [Inject(Id = "Chomper123")] public string UnitName { get; }
        [Inject(Id = "Chomper123")] public Sprite Icon { get; }
        [Inject(Id = "Chomper123")] public float ProductionTime { get; }
       public GameObject UnitPrefab => _unitPrefab;
        [InjectAsset("Chomper123")] private GameObject _unitPrefab;
    }
}