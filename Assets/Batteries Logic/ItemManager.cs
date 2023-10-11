using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    private Battery currentItem;

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.E) && currentItem != null)
        {
            currentItem.Execute();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Battery"))
            return;

        currentItem = other.GetComponent<Battery>();
        currentItem.OnEnter();
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.gameObject.CompareTag("Battery"))
            return;

        if (currentItem != null)
        {
            currentItem.OnExit();
            currentItem = null;
        }
    }
}
