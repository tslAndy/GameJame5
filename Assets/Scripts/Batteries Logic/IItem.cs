using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IItem
{
    public void Execute(ItemManager context);
    public void OnEnter();
    public void OnExit();
}
