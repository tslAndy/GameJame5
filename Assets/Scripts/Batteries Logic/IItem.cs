using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IItem
{
    public void Execute();
    public void OnEnter();
    public void OnExit();
}