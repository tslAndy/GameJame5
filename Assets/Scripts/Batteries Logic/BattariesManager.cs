using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BattariesManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _collectedBattariesText;
    private int _batteriesAmount;
    private void OnEnable()
    {
        GameManager.instance.OnItemPickedUp += AddBattary;
    }
    private void OnDisable()
    {
        GameManager.instance.OnItemPickedUp -= AddBattary;
    }
    public void UseBattery()
    {
        if(_batteriesAmount > 0)
        {
            _batteriesAmount -= 1;
            UpdateText();
            //increase the cameras energy to max
        }
    }
    private void UpdateText()
    {
        _collectedBattariesText.text = "Battaries collected: " + _batteriesAmount;
    }
    void AddBattary(string tag)
    {
        if(tag == "Battery")
        {
            _batteriesAmount++;
            UpdateText();
        }
    }
}
