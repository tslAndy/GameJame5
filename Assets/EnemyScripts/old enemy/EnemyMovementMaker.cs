using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementMaker : MonoBehaviour
{
    [SerializeField] List<Transform> _targets = new List<Transform>();
    [SerializeField] private Enemy _enemy;
    [SerializeField] private float _viewingRange;

    bool _isChasingPlayer;
    bool _playerIsVisible;
    private void Awake()
    {
        //_enemy.SetMover(new NavMeshChasing());
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            //_enemy.SetMover(new NavMeshChasing());
        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            //_enemy.SetMover(new NavMeshPatrol(_targets, _enemy));
        }
    }

}
