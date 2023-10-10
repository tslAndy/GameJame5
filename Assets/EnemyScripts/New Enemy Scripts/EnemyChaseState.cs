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
    float MinDistance = 3f;
    RaycastHit hit;

    ///////Timer/////////
    float waitUntilNextCheck = 5f;
    float timer;


    public EnemyChaseState(EnemyStateManager context, IEnemy enemy)
    {
           _context = context;
           _enemy = enemy;
    }
    public override void EnterState()
    {
           timer = waitUntilNextCheck;
           Debug.Log("Chasing");
    }
    public override void UpdateState()
    {
        Debug.Log("Update Chase");
           if (Time.time > timer + waitUntilNextCheck)
           {
               CheckForThePlayer();
               timer = Time.time;
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
            Debug.Log("Making raycasts in chase");
               Vector3 direction = _enemy.Transform.forward.Rotate((centerIndex - i) * _enemy.RaycastsAngle);
               Physics.Raycast(_enemy.Transform.position, direction, out hit, _enemy.ViewingRange, _enemy.HittingLayer);
               Debug.DrawRay(_enemy.Transform.position, direction * _enemy.ViewingRange, Color.green);
               if(hit.collider != null )
               {
                   _enemy.NavMeshAgent.SetDestination(hit.transform.position);    // Set the destanation to the players position
                   _enemy.NavMeshAgent.speed = _enemy.ChasingSpeed;                  // Set the NavMash's speed to Chasing
                   _enemy.NavMeshAgent.isStopped = false;                  // Set the NavMash's speed to Chasing
                if (_enemy.NavMeshAgent.remainingDistance < MinDistance)          // if remaining distance until the player is small -> game ended
                   {
                       OmGameEnded?.Invoke();
                   }
                break;
               }
               else
               {
                   _context.SwitchState(_context.patrolState);
               }
           }
    }
}
