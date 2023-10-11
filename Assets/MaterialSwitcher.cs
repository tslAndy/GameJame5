using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialSwitcher : MonoBehaviour
{
    public Material material1;
    public Material material2;
    public float maxEnergy = 100f;
    public float energyRechargeRate = 1f;
    public float energyDrainRate = 1f;

    private Renderer objectRenderer;
    private float currentEnergy;
    private bool isMaterial2Active;

    private void Start()
    {
        objectRenderer = GetComponent<Renderer>();
        objectRenderer.material = material1; // Start with material 1
        currentEnergy = maxEnergy;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (!isMaterial2Active)
            {
                // If material 1 is active, switch to material 2
                objectRenderer.material = material2;
                isMaterial2Active = true;
            }
            else if (currentEnergy > 0)
            {
                // If material 2 is active and energy is available, switch to material 1
                objectRenderer.material = material1;
                isMaterial2Active = false;
            }
        }

        UpdateEnergy();
    }

    private void UpdateEnergy()
    {
        if (isMaterial2Active)
        {
            // Drain energy when material 2 is active
            currentEnergy -= energyDrainRate * Time.deltaTime;
            currentEnergy = Mathf.Max(currentEnergy, 0f); // Ensure energy doesn't go below zero
        }
        else
        {
            // Recharge energy when material 1 is active
            currentEnergy += energyRechargeRate * Time.deltaTime;
            currentEnergy = Mathf.Min(currentEnergy, maxEnergy); // Ensure energy doesn't exceed the maximum
        }
    }
}
