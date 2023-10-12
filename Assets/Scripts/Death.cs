using UnityEngine;

public class Death : MonoBehaviour
{
    [SerializeField]
    private GameObject _deathScreen;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            _deathScreen?.SetActive(true);
        }
    }
}
