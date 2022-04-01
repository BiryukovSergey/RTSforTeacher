using Abstractions;
using Abstractions.Commands;
using Abstractions.Commands.CommandsInterfaces;
using UnityEngine;

public sealed class MainBuilding : CommandExecutorBase<IProduceUnitCommand>, ISelecatable
{
    [SerializeField] private Transform _unitsParent;
    [SerializeField] private Transform _pivotPoint;
    [SerializeField] private float _maxHealth = 1000;
    [SerializeField] private Sprite _icon;


    private float _health = 1000;
    public float Health => _health;
    public float MaxHealth => _maxHealth;
    public Sprite Icon => _icon;
    public Vector3 PositionIllusion => transform.position;

    public Transform PivotPoint => _pivotPoint;

    public override void ExecuteSpecificCommand(IProduceUnitCommand command) 
        => Instantiate(command.UnitPrefab, 
            new Vector3(Random.Range(-10, 10), 0.2f, Random.Range(-10, 10)), 
            Quaternion.identity, 
            _unitsParent);
}