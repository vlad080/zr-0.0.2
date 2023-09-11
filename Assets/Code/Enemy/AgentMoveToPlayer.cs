using System.Collections;
using Code.Character;
using Code.Data;
using Code.Infrastructure.Factory;
using Code.Player;
using UnityEngine;
using UnityEngine.AI;

namespace Code.Enemy
{
    public class AgentMoveToPlayer : Follow
    {
        public NavMeshAgent Agent;
        private Transform _target;
        private IGameFactory _gameFactory;
        
        
        private void Start()
        {
            StartCoroutine(GetTarget());
        }

        private IEnumerator GetTarget()
        {
            yield return new WaitForSeconds(1);
            _target = FindObjectOfType<CharacterMovement>().transform;
        }

        private void Update()
        {
            if(_target != null && IsHeroNotReached())
                Agent.destination = _target.position;
        }
    
        private bool IsHeroNotReached() => 
            Agent.transform.position.SqrMagnitudeTo(_target.position) >= Constants.MinimalDistance;
    }
}
