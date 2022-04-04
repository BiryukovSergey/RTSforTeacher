using UnityEngine;

namespace Abstractions
{
    public interface ISelecatable : IHealthHolder
    {
        float Health { get; }
        float MaxHealth { get; }
        Sprite Icon { get; }
        Vector3 PositionIllusion { get; }
        Transform PivotPoint { get; }
    }
}