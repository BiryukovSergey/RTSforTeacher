using Abstractions;
using Abstractions.Commands;
using Abstractions.Commands.CommandsInterfaces;
using UnityEngine;

public class Chompers : CommandExecutorBase<IAttackCommand>,ISelecatable
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


    public override void ExecuteSpecificCommand(IAttackCommand command)
    {
        Debug.Log("Attack");
    }
}
