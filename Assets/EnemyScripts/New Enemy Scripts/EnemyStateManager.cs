using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateManager : MonoBehaviour
{
    [SerializeField] List<Transform> _targets = new List<Transform>();
    [SerializeField] private Enemy _enemy;

    public EnemyChaseState chaseState; 
    public EnemyPatrolState patrolState; 
    public EnemyBaseState _currentState;

    public bool isPlayerVisible = true;
    [HideInInspector] public bool isMoving = true;

    private void Awake()
    {
        chaseState = new EnemyChaseState(this, _enemy);
        patrolState = new EnemyPatrolState(_targets, _enemy, this);
        _currentState = patrolState;
        _currentState.EnterState();
    }

    private void Update()
    {
        _currentState.UpdateState();
    }
    public void SwitchState(EnemyBaseState state)
    {
        _currentState.ExitState();
        _currentState = state;
        _currentState.EnterState();
    }
}