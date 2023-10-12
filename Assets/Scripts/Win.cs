using UnityEngine;

public class Win : MonoBehaviour
{
    [SerializeField]
    private ItemManager _collectedCards;
    [SerializeField]
    private GameObject _winScreen;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Exit"))
        {
            //_collectedCards.ShowExitStatus();
            if (_collectedCards.allCardsCollected)
            {
                _winScreen.SetActive(true);
            }
        }
    }
}
