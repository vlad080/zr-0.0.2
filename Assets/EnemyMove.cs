using Code.Character;
using Code.Player;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour
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
