using TMPro;
using UnityEngine;

public class CardCollector : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _collectedCardText;
    [SerializeField]
    private Subtitles _subtitles;
    [SerializeField]
    private int _cardsTotal = 3;
    private int _score = 0;

    private void Start()
    {
        _subtitles ??= GetComponent<Subtitles>();
        UpdateCardText();
    }

    private void UpdateCardText()
    {
        _collectedCardText.text = "Cards collected: " + _score + "/" + _cardsTotal;
    }

    private void ShowExitStatus()
    {
        string exitStatus;
        if (_score < _cardsTotal)
        {
            exitStatus = "I need all the access cards to exit this building...";
        }
        else
        {
            exitStatus = "The door opened!";
        }
        _subtitles.AddLine(exitStatus);
        _subtitles.TriggerSubtitles();
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
}
