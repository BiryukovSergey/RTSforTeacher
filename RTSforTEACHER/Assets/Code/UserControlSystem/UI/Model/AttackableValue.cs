using Abstractions;
using Code.Utils;
using UnityEngine;

namespace UserControlSystem
{
   [CreateAssetMenu(fileName = nameof(AttackableValue), menuName = "Strategy Game/" + nameof(AttackableValue), order = 0)]
    public class AttackableValue : StatelessScriptableObjectValueBase<IAttackable>
    {
    }
}