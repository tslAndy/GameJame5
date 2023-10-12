using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Extensions;
public class EnemyPatrolState : EnemyBaseState
{
    IEnemy _enemy;
    EnemyStateManager _context;
    List<Vector3> _targets;
    private Vector3 _currentTarget;
    private float MinDistance = 0.5f;
    RaycastHit hit;

    public EnemyPatrolState(IEnumerable<Transform> targets, IEnemy enemy, EnemyStateManager context)
    {
        _context = context;
        _enemy = enemy;
        _targets = targets.Select(target => target.transform.position).ToList();

    }

    public override void EnterState()
    {
        _context.isMoving = true;
        Debug.Log("Entered patrol");
        _enemy.NavMeshAgent.isStopped = false;
        SwitchTarget();
    }
    public override void UpdateState()
    {
          ObserveForPlayer();
          if (!_context.isMoving)   // if not moving - do nothing
              return;

          if (_enemy.NavMeshAgent.remainingDistance < MinDistance)   // if remaining distance is too small -> path was complited
          {
            SwitchTarget();
          }
          //Debug.Log("Patrol Update");
    }
    public override void ExitState()
    {
         _enemy.NavMeshAgent.isStopped = true;
         _context.isMoving = false;
    }

    private void SwitchTarget()  // set new random from the target list Vector3 target 
    {
         var rand = new System.Random();
         _currentTarget = _targets[rand.Next(0, _targets.Count)];
        _enemy.NavMeshAgent.SetDestination(_currentTarget);    // Set the destanation for IEnemy's NavMesh
        _enemy.NavMeshAgent.speed = _enemy.Speed;    // Set the NavMash's speed
    }
    private void ObserveForPlayer()
    {

        if (!_context.isPlayerVisible) return;

        int centerIndex = _enemy.RaycastsAmount / 2;

        for (int i = 0; i < _enemy.RaycastsAmount; i++)
        {
            Vector3 direction = _enemy.Transform.forward.Rotate((centerIndex - i) * _enemy.RaycastsAngle);
            Physics.Raycast(_enemy.Transform.position, direction * _enemy.ViewingRange, out hit, _enemy.ViewingRange, _enemy.HittingLayer);
            Debug.DrawRay(_enemy.Transform.position, direction * _enemy.ViewingRange, Color.green);
            if (hit.collider != null)
            {
                _context.SwitchState(_context.chaseState);
                break;
            }
        }
       
    } 
}
