using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour, IEnemy
{
    [SerializeField] NavMeshAgent _navMeshAgent;
    [SerializeField] float _speed;
    private IMover _mover = new NavMeshChasing();

    public NavMeshAgent NavMeshAgent => _navMeshAgent;
    public float Speed => _speed;

    void Update()
    {
        _mover.UpdateMove(Time.deltaTime);
    }
    public void SetMover(IMover mover)
    {
        if(mover != null)
        {
            _mover.StopMove();
        }
        _mover = mover;
        _mover.StartMove();
    }
}
