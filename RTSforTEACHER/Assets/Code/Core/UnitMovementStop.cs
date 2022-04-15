using System;
using Code.UserControlSystem.UI.Model;
using Code.Utils;
using UnityEngine;
using UnityEngine.AI;

namespace Code.Core
{
    public class 
        UnitMovementStop : MonoBehaviour, IAwaitable<AsyncExtensions.Void>
    {
        public event Action OnStop;
        [SerializeField] private NavMeshAgent _agent;

        void Update()
        {
            if (!_agent.pathPending)
            {
                if (_agent.remainingDistance <= _agent.stoppingDistance)
                {
                    if (!_agent.hasPath || _agent.velocity.sqrMagnitude == 0f)
                    {
                        OnStop?.Invoke();
                    }
                }
            }
        }

        public IAwaiter<AsyncExtensions.Void> GetAwaiter() => new StopAwaiter(this);
    }
    
}