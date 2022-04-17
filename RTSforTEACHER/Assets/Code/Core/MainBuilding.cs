using System.Threading.Tasks;
using Abstractions;
using Abstractions.Commands;
using Abstractions.Commands.CommandsInterfaces;
using UnityEngine;

public sealed class MainBuilding : CommandExecutorBase<IProduceUnitCommand>,ISelectable, IAttackable, IPatrolCommand
{
    [SerializeField] private Transform _unitsParent;
    [SerializeField] private float _maxHealth = 1000;
    [SerializeField] private Sprite _icon;
    [SerializeField] private Transform _pivotPoint;

    public Vector3 From { get; }
    
    public Vector3 To { get; }
    public Vector3 RallyPoint { get; set; }

    
    private float _health = 1000;
    public float Health => _health;
    public float MaxHealth => _maxHealth;
    public Sprite Icon => _icon;
    public Vector3 PositionIllusion => transform.position;
    public Transform PivotPoint => _pivotPoint;


    public override async Task ExecuteSpecificCommand(IProduceUnitCommand command)
    {
    }
}