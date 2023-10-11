using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattariesManager : MonoBehaviour
{
    public int BatteriesAmount;
    [SerializeField] private Image _UICameraImage;
    [SerializeField] private Image _energyDecreasingTime;
    private bool _usingCamera;
    private void OnEnable()
    {
        GameManager.instance.OnItemPickedUp += HandleBattaryPickUp;
    }
    private void OnDisable()
    {
        GameManager.instance.OnItemPickedUp -= HandleBattaryPickUp;
    }
    private void Update()
    {

    }
    void UseBattery()
    {
        if(BatteriesAmount > 0)
        {
            BatteriesAmount -= 1;
            //increase the cameras energy to max
        }
    }
    void HandleBattaryPickUp(string name)
    {
        if(name == "Battery")
        {
            Debug.Log("Picked Battery " + BatteriesAmount);

            BatteriesAmount++;
        }
    }
}
