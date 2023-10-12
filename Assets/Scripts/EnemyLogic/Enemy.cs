using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour, IEnemy
{
    [SerializeField] NavMeshAgent _navMeshAgent;
    [SerializeField] float _speed;
    [SerializeField] float _viewingRange;
    [SerializeField] LayerMask _hittingLayer;
    [SerializeField] int _raycastsAmount;
    [SerializeField] float _raycastsAngle;
    [SerializeField] float _chasingSpeed;
    [SerializeField] float _waitUntilNextCheck;
    [SerializeField] float _waitwaitUntilStartPatrol;

    public NavMeshAgent NavMeshAgent => _navMeshAgent;
    public float Speed => _speed;

    public Transform Transform => transform;

    public float ViewingRange => _viewingRange;

    public LayerMask HittingLayer => _hittingLayer;

    public int RaycastsAmount => _raycastsAmount;

    public float RaycastsAngle => _raycastsAngle;
    public float ChasingSpeed => _chasingSpeed;
    public float WaitUntileNextCheck => _waitUntilNextCheck;
    public float WaitUnileStartPatrol => _waitwaitUntilStartPatrol;

    /*
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
    */
}