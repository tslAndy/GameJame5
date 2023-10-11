using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public interface IEnemy
{
     float Speed { get; }
     NavMeshAgent NavMeshAgent{ get; }
     Transform Transform { get; }
     float ViewingRange { get; }
     LayerMask HittingLayer { get; }
     int RaycastsAmount { get; }
     
     float RaycastsAngle { get; }
     float ChasingSpeed { get; }
     float WaitUntileNextCheck { get; }
     float WaitUnileStartPatrol { get; }
}
