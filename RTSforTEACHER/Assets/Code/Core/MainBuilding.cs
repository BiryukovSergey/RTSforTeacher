using System.Threading.Tasks;
using Abstractions;
using Abstractions.Commands;
using Abstractions.Commands.CommandsInterfaces;
using UnityEngine;
using UnityEngine.UIElements;

public sealed class MainBuilding : CommandExecutorBase<IProduceUnitCommand>, ISelecatable, IAttackable, IPatrolCommand
{
    [SerializeField] private Transform _unitsParent;
    [SerializeField] private float _maxHealth = 1000;
    [SerializeField] private Sprite _icon;
    [SerializeField] private Transform _pivotPoint;

    private float _health = 1000;
    public float Health => _health;
    public float MaxHealth => _maxHealth;
    public Sprite Icon => _icon;
    public Vector3 PositionIllusion => transform.position;
    public Transform PivotPoint => _pivotPoint;

    public async override void ExecuteSpecificCommand(IProduceUnitCommand command)
    {
        await Task.Delay(1000);
        Instantiate(command.UnitPrefab, new Vector3(Random.Range(-10, 10), 0.2f, Random.Range(-10, 10)), Quaternion.identity, _unitsParent);
    }

    public Vector3 From { get; }
    public Vector3 To { get; }
}