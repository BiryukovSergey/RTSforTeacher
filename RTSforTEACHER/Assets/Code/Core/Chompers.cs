using System.Threading.Tasks;
using Abstractions;
using Abstractions.Commands;
using Abstractions.Commands.CommandsInterfaces;
using UnityEngine;

public class Chompers : CommandExecutorBase<IAttackCommand>,ISelectable,IMoveCommand, IAttackable, IPatrolCommand,IUnit
{
    [SerializeField] private float _maxHealth = 250;
    [SerializeField] private Sprite _icon;
    [SerializeField] private Transform _pivotPoint;
    
    private float _health = 250;
    public float Health => _health;
    public float MaxHealth => _maxHealth;
    public Sprite Icon => _icon;
    
    public Vector3 PositionIllusion => transform.position;
    public Transform PivotPoint => _pivotPoint;


    public override async Task ExecuteSpecificCommand(IAttackCommand command)
    {
        Debug.Log("Attack");
    }

    public Vector3 Target { get; }
    public Vector3 From { get; }
    public Vector3 To { get; }
}
