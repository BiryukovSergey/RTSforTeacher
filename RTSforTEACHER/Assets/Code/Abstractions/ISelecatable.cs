using Abstractions.Commands;
using UnityEngine;

namespace Abstractions
{
    public interface ISelecatable : IHealthHolder
    {
        Sprite Icon { get; }
        Vector3 PositionIllusion { get; }
        Transform PivotPoint { get; }
    }
}