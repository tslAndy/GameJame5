using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateManager : MonoBehaviour
{
    [SerializeField] List<Transform> _targets = new List<Transform>();
    [SerializeField] private Enemy _enemy;
    [SerializeField] private EnemyAnimationController animationController;

    public EnemyChaseState chaseState;
    public EnemyPatrolState patrolState;
    public EnemyBaseState _currentState;

    [HideInInspector] public bool isPlayerVisible = true;
    [HideInInspector] public bool isMoving = true;

    private void OnEnable()
    {
        SafeSpot.OnPlayerInSafeSpot += delegate (bool isIt) { isPlayerVisible = isIt; Debug.Log("Performed delegate"); };
    }
    private void OnDisable()
    {

    }
    private void Awake()
    {
        animationController = GetComponent<EnemyAnimationController>();
        chaseState = new EnemyChaseState(this, _enemy);
        patrolState = new EnemyPatrolState(_targets, _enemy, this);
        _currentState = patrolState;
        _currentState.EnterState();
    }

    private void Update()
    {
        _currentState.UpdateState();

        // Check if the enemy is chasing or searching and set animations accordingly
        if (_currentState == chaseState)
        {
            animationController.SetChaseAnimation();
        }
        else if (_currentState == patrolState)
        {
            animationController.SetSearchAnimation();
        }
    }
    public void SwitchState(EnemyBaseState state)
    {
        _currentState.ExitState();
        _currentState = state;
        _currentState.EnterState();
    }
}