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
    private bool isRenderMaterialActive;

    private void Start()
    {
        objectRenderer = GetComponent<Renderer>();
        objectRenderer.material = material1; // Start with material 1 (black screen)
        currentEnergy = maxEnergy;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (!isRenderMaterialActive)
            {
                // If material 1 is active, switch to material 2
                objectRenderer.material = material2;
                isRenderMaterialActive = true;
            }
            else if (currentEnergy > 0)
            {
                // If material 2 is active and energy is available, switch to material 1
                objectRenderer.material = material1;
                isRenderMaterialActive = false;
            }
        }

        UpdateEnergy();
    }

    private void UpdateEnergy()
    {
        if (isRenderMaterialActive)
        {
            // Drain energy when material 2 is active
            currentEnergy -= energyDrainRate * Time.deltaTime;
            currentEnergy = Mathf.Max(currentEnergy, 0f); // Ensure energy doesn't go below zero
            if (currentEnergy <= 0)
            {
                objectRenderer.material = material1;
                isRenderMaterialActive = false;
            }
        }
        else
        {
            // Recharge energy when material 1 is active
            currentEnergy += energyRechargeRate * Time.deltaTime;
            currentEnergy = Mathf.Min(currentEnergy, maxEnergy); // Ensure energy doesn't exceed the maximum
        }
    }
}
