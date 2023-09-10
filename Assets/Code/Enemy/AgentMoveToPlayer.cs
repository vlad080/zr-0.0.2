using Code.Character;
using UnityEngine;
using UnityEngine.AI;

namespace Code.Enemy
{
    public class AgentMoveToPlayer : MonoBehaviour
    {
        private Transform _target;
        public NavMeshAgent Agent;

        private void Start()
        {
            _target = FindObjectOfType<CharacterMovement>().transform;
            MoveToTarget();
        }

        private void MoveToTarget()
        {
            Agent.destination = _target.transform.position;
        }
    }
}
