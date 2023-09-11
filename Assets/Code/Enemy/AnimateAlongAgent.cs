using Code.Player;
using UnityEngine;
using UnityEngine.AI;

namespace Code.Enemy
{
    [RequireComponent(typeof(NavMeshAgent))]
    [RequireComponent(typeof(EnemyAnimator))]
    public class AnimateAlongAgent : MonoBehaviour
    {
        [SerializeField] private NavMeshAgent Agent;
        [SerializeField] private EnemyAnimator Animator;

        private void Update()
        {
            if (ShouldMove())
                Animator.Move(Agent.velocity.magnitude);
            else
                Animator.StopMoving();
        }

        private bool ShouldMove() =>
            Agent.velocity.magnitude > Constants.MinimalVelocity && Agent.remainingDistance > Agent.radius;
    }
}