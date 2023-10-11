using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeSpot : MonoBehaviour
{
    public delegate void InSafeSpot(bool isIt);
    public static event InSafeSpot OnPlayerInSafeSpot;
    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.CompareTag("Player"))
        {
            OnPlayerInSafeSpot?.Invoke(false);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            OnPlayerInSafeSpot?.Invoke(true);
        }
    }
}
