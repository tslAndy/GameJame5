using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    //public float pickableDistance;
    //public LayerMask maskThatOick;
    [SerializeField] private GameObject pressEText;
    [SerializeField] private Transform _player;
    public Transform Player {
        get
        {
            return _player;
        }
    }
    public delegate void PickingItemUp(string itemName);
    public event PickingItemUp OnItemPickedUp;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }
    private void Start()
    {
        pressEText.SetActive(false);
    }
    public void InvokeOnItemPickedUp(string name)
    {
        OnItemPickedUp?.Invoke(name);
    }
    public bool IsPressTextActive() {
        if(pressEText.activeSelf)
        {
            return true;
        }
        else
        {
            return false;
        }
     }
    public void SetPressTextActivness(bool toWhat)
    {
        pressEText.SetActive(toWhat);
    }
}
