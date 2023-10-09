using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public interface IEnemy
{
     float Speed { get; }
     NavMeshAgent NavMeshAgent{ get; }
}
