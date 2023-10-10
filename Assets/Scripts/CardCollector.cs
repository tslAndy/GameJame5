using TMPro;
using UnityEngine;

public class CardCollector : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _collectedCardText;
    [SerializeField]
    private int _cardsTotal = 3;
    private int _score = 0;

    private void Start()
    {
        UpdateCardText();
    }

    private void UpdateCardText()
    {
        _collectedCardText.text = "Cards collected: " + _score + "/" + _cardsTotal;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Card"))
        {
            other.gameObject.SetActive(false); // We don't want the player to pick up one card several times
            ++_score;
            UpdateCardText();
        }
    }
}
