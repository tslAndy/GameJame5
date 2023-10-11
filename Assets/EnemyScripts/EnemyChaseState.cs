using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Extensions;

public class EnemyChaseState : EnemyBaseState
{
    public delegate void GameEnded();
    public event GameEnded OmGameEnded;
    IEnemy _enemy;
    EnemyStateManager _context;
    float MinDistance = 2.5f;
    RaycastHit hit;

    ///////Timer/////////
    float checkTimer;
    float waitTimer;

    Vector3 _targetPosition;


    public EnemyChaseState(EnemyStateManager context, IEnemy enemy)
    {
           _context = context;
           _enemy = enemy;
    }
    public override void EnterState()
    {
           checkTimer = _enemy.WaitUntileNextCheck;
           waitTimer = _enemy.WaitUnileStartPatrol;
    }
    public override void UpdateState()
    {
           if (Time.time > checkTimer + _enemy.WaitUntileNextCheck)
           {
               CheckForThePlayer();
               checkTimer = Time.time;
           }
    }

    public override void ExitState()
    {
    }

    private void CheckForThePlayer()
    {
           int centerIndex = _enemy.RaycastsAmount / 2;

           for (int i = 0; i < _enemy.RaycastsAmount; i++)
           {
               Vector3 direction = _enemy.Transform.forward.Rotate((centerIndex - i) * _enemy.RaycastsAngle);
               Physics.Raycast(_enemy.Transform.position, direction, out hit, _enemy.ViewingRange, _enemy.HittingLayer);
               Debug.DrawRay(_enemy.Transform.position, direction * _enemy.ViewingRange, Color.green);
               if(hit.collider != null )
               {
                   _targetPosition = hit.collider.transform.position;
                   _enemy.NavMeshAgent.SetDestination(_targetPosition);    // Set the destanation to the players position
                   _enemy.NavMeshAgent.speed = _enemy.ChasingSpeed;                  // Set the NavMash's speed to Chasing
                   _enemy.NavMeshAgent.isStopped = false;                  // Set the NavMash's speed to Chasing
                if (_enemy.NavMeshAgent.remainingDistance < MinDistance)          // if remaining distance until the player is small -> game ended
                   {
                       OmGameEnded?.Invoke();
                   }
                break;
               }
               else                                                 // If eney lost player -- go to the last player where the player was
               {
                   _enemy.NavMeshAgent.SetDestination(_targetPosition);
                   if (_enemy.NavMeshAgent.remainingDistance < MinDistance)         
                   {
                    if (Time.time > waitTimer + _enemy.WaitUnileStartPatrol)
                    {
                        waitTimer = Time.time;
                        _context.SwitchState(_context.patrolState);
                    }
                   }
               }
           }
    }
}
