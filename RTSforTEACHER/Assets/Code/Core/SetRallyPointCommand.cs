using Abstractions;
using UnityEngine;

namespace Code.Core
{
    public class SetRallyPointCommand : ISetRallyPointCommand

    {
        public Vector3 RallyPoint { get; }

        public SetRallyPointCommand(Vector3 rallyPoint)
        {
            RallyPoint = rallyPoint;
        }
    }
}