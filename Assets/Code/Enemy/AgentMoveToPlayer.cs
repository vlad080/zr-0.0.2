using Code.Character;
using Code.Data;
using Code.Infrastructure.Factory;
using Code.Player;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

namespace Code.Enemy
{
    public class AgentMoveToPlayer : MonoBehaviour
    {
        public NavMeshAgent Agent;
        private Transform _target;
        private IGameFactory _gameFactory;
        [Inject]
        public void Construct(IGameFactory gameFactory)
        {
            _gameFactory = gameFactory;
        }

        private void Start()
        {
            _target = FindObjectOfType<CharacterMovement>().transform;
        }

        private void Update()
        {
            if(_target && IsHeroNotReached())
                Agent.destination = _target.position;
        }
    
        private bool IsHeroNotReached() => 
            Agent.transform.position.SqrMagnitudeTo(_target.position) >= Constants.MinimalDistance;
    }
}
