using Abstractions;
using Code.Utils;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using ISelectable = Abstractions.ISelectable;

namespace UserControlSystem
{
    [CreateAssetMenu(fileName = nameof(SelectableValue), menuName = "Strategy Game/" + nameof(SelectableValue), order = 0)]
    public class SelectableValue : StatefulScriptableObjectValueBase<ISelectable>
    {
       
    }
}