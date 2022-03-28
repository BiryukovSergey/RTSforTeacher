using Abstractions;
using Abstractions.Commands;
using Abstractions.Commands.CommandsInterfaces;
using UnityEngine;
using UnityEngine.UIElements;

public class Chompers : CommandExecutorBase<IAttackCommand>,ISelectable
{
    [SerializeField] private float _maxHealth = 250;
    [SerializeField] private Sprite _icon;
    
    private float _health = 250;
    public float Health => _health;
    public float MaxHealth => _maxHealth;
    public Sprite Icon => _icon;
    
    public Vector3 PositionIllusion => transform.position;


    public override void ExecuteSpecificCommand(IAttackCommand command)
    {
        Debug.Log("Attack");
    }
}
