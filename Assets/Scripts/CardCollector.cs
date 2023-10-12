using System.Collections;
using TMPro;
using UnityEngine;

public class CardCollector : MonoBehaviour
{
    public bool allCardsCollected = false;
    [SerializeField]
    private TextMeshProUGUI _collectedCardText;
    [SerializeField]
    private Subtitles _subtitles;
    [SerializeField]
    private int _cardsTotal = 3;
    [SerializeField]
    private float _triggerCooldown;
    private int _score = 0;
    private bool _isOnCooldown = false;

    private void Start()
    {
        _subtitles ??= GetComponent<Subtitles>();
        UpdateCardText();
    }

    private void UpdateCardText()
    {
        _collectedCardText.text = "Cards collected: " + _score + "/" + _cardsTotal;
    }

    public void ShowExitStatus()
    {
        if (_isOnCooldown) return;
        string exitStatus;
        if (_score < _cardsTotal)
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Card"))
        {
            other.gameObject.SetActive(false); // We don't want the player to pick up one card several times
            ++_score;
            UpdateCardText();
        }
        else if (other.gameObject.CompareTag("Exit"))
        {
            ShowExitStatus();
        }
    }

    private IEnumerator TriggerCooldown()
    {
        yield return new WaitForSeconds(_triggerCooldown);
        _isOnCooldown = false;
    }
}
