using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMover 
{
    void StartMove();
    void UpdateMove(float deltaTime);
    void StopMove();
}
