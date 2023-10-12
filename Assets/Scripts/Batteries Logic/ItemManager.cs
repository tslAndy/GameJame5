using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public bool allCardsCollected = false;
    [SerializeField] private TextMeshProUGUI _collectedCardText;
    [SerializeField] private Subtitles _subtitles;
    [SerializeField] private int _cardsTotal = 3;
    [SerializeField] private float _triggerCooldown;
    private int _cardScore = 0;
    [SerializeField] private TextMeshProUGUI _collectedBattariesText;
    private int _batteriesAmount = 0;
    private bool _isOnCooldown = false;
    private IItem currentItem;

    public delegate void UsingBattary();
    public static event UsingBattary OnBattaryUsed;

    private void Start()
    {
        _subtitles ??= GetComponent<Subtitles>();
        UpdateCardText();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && currentItem != null)
        {
            currentItem.Execute(this);
            currentItem = null;
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            UseBattary();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.TryGetComponent(out Battery battery))
        {
            currentItem = battery;
            currentItem.OnEnter();
            return;
        }
        else if (other.transform.TryGetComponent(out Card cart))
        {
            currentItem = cart;
            currentItem.OnEnter();
        }
        else if (other.gameObject.CompareTag("Exit"))
        {
            ShowExitStatus();     
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Battery") && currentItem != null)
        {
            currentItem.OnExit();
            currentItem = null;
        }
        if (other.gameObject.CompareTag("Card") && currentItem != null)
        {
            currentItem.OnExit();
            currentItem = null;
        }
    }
    ///////// CARD  /////////

    public void LogicForCardToUpdate()
    {
        ++_cardScore;
        UpdateCardText();
        UpdateBatteryText();
    }

    private void UpdateCardText()
    {
        _collectedCardText.text = "Cards collected: " + _cardScore + "/" + _cardsTotal;
    }
    public void ShowExitStatus()
    {
        if (_isOnCooldown) return;
        string exitStatus;
        if (_cardScore < _cardsTotal)
        {
            exitStatus = "I need all the access cards to exit this building...";
        }
        else
        {
            allCardsCollected = true;
            exitStatus = "The door opened!";
        }
        _subtitles.OverwriteLinesWithLine(exitStatus);
        _subtitles.TriggerSubtitles();
        _isOnCooldown = true;
        StartCoroutine(TriggerCooldown());
    }
    private IEnumerator TriggerCooldown()
    {
        yield return new WaitForSeconds(_triggerCooldown);
        _isOnCooldown = false;
    }
    ///////// CARD  /////////
    ///////// BATTARY  /////////
    public void AddBattary()
    {
        _batteriesAmount++;
        UpdateBatteryText();
    }
    public void UseBattary()
    {
        if (_batteriesAmount > 0)
        {
            _batteriesAmount -= 1;
            UpdateBatteryText();
            OnBattaryUsed?.Invoke();   //increase the cameras energy to max
        }
    }
    private void UpdateBatteryText()
    {
        _collectedBattariesText.text = "Battaries collected: " + _batteriesAmount;
    }
}
