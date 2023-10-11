using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshPatrol : IMover
{
    IEnemy _enemy;
    List<Vector3> _targets;
    private bool _isMoving;
    private Vector3 _currentTarget;
    private float MinDistance = 0.5f;

    bool _isChasingPlayer;
    bool _playerIsVisible;

    public NavMeshPatrol(IEnumerable<Transform> targets, IEnemy enemy)
    {
        _enemy = enemy;
        _targets = targets.Select(target => target.transform.position).ToList();

    }
    public void StartMove()
    {
        _isMoving = true;
        SwitchTarget();
    }
    public void UpdateMove(float deltaTime)
    {
        if (!_isMoving)   // if not moving - do nothing
            return;
        _enemy.NavMeshAgent.SetDestination(_currentTarget);    // Set the destanation for IEnemy's NavMesh
        _enemy.NavMeshAgent.speed = _enemy.Speed;    // Set the NavMash's speed
        if ((_currentTarget - _enemy.Transform.position).magnitude < MinDistance)   // if remaining distance is too small -> path was complited
        {
            SwitchTarget();    // Switch target
        }
     }
    private void ObserveForPlayer()
    {
        Physics.Raycast(_enemy.Transform.position, _enemy.Transform.forward, out RaycastHit hit);
        {
            if (hit.transform.CompareTag("Player"))
            {
                if(_playerIsVisible && _isChasingPlayer)
                {

                }
            }
        }
    }
    public void StopMove()
    {
        _isMoving = false;
    }
    private void SwitchTarget()  // set new random from the target list Vector3 target 
    {
        if(_currentTarget!= null)
        {
            _targets.Add(_currentTarget);
        }
        var rand = new System.Random();
        _currentTarget = _targets[rand.Next(0,_targets.Count)];
    }
}
