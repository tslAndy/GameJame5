using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickable : MonoBehaviour
{
    Vector3 distanceToPlayer;
    
    private void Update()
    {
        distanceToPlayer = GameManager.instance.Player.position - transform.position;
        if (distanceToPlayer.magnitude < GameManager.instance.pickableDistance)
        {
            Debug.Log("CLode!");
            if (!GameManager.instance.IsPressTextActive())
            {
                GameManager.instance.SetPressTextActivness(true);
            }
        }
        else
        {
            if (GameManager.instance.IsPressTextActive())
            {
                GameManager.instance.SetPressTextActivness(false);
            }
        }
    }
    
    /*
    private void Update()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, GameManager.instance.pickableDistance, GameManager.instance.maskThatOick);
        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.gameObject.tag == "Player")
            {
                if (!GameManager.instance.IsPressTextActive())
                {
                    GameManager.instance.SetPressTextActivness(true);
                }
                if (Input.GetKeyDown(KeyCode.E))
                {
                    GameManager.instance.InvokeOnItemPickedUp(gameObject.tag);
                    Destroy(gameObject);
                }
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            GameManager.instance.SetPressTextActivness(false);
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(transform.position, GameManager.instance.pickableDistance);
    }
    */
}
