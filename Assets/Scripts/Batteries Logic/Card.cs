using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour, IItem
{
    public void Execute(ItemManager context)
    {
        GameManager.instance.InvokeOnItemPickedUp(gameObject.tag);
        context.LogicForCardToUpdate();
        OnExit();
        Destroy(gameObject);
    }

    public void OnEnter()
    {
        if (!GameManager.instance.IsPressTextActive())
            GameManager.instance.SetPressTextActivness(true);
    }

    public void OnExit()
    {
        if (GameManager.instance.IsPressTextActive())
            GameManager.instance.SetPressTextActivness(false);
    }

    public void Use(ItemManager context)
    {
    }
}
