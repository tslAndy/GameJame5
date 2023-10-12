using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeSpot : MonoBehaviour
{
    [SerializeField] private GameObject redLight, greenLight;
    public delegate void InSafeSpot(bool isIt);
    public static event InSafeSpot OnPlayerInSafeSpot;
    private void OnTriggerEnter(Collider other)
    {
        if (!other.transform.CompareTag("Player")) return;
        redLight.SetActive(false);
        greenLight.SetActive(true);

        OnPlayerInSafeSpot?.Invoke(false);
    }
    private void OnTriggerExit(Collider other)
    {
        if (!other.transform.CompareTag("Player")) return;
        redLight.SetActive(true);
        greenLight.SetActive(false);
        OnPlayerInSafeSpot?.Invoke(true);
    }
}
