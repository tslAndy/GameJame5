using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MaterialSwitcher : MonoBehaviour
{
    public Material material1;
    public Material material2;
    public float maxEnergy = 100f;
    public float energyRechargeRate = 1f;
    public float energyDrainRate = 1f;
    public float energyRequirement = 10f; // How much energy is needed to turn on the camera

    [SerializeField]
    private TextMeshProUGUI _chargeText;
    [SerializeField]
    private GameObject _lowChargeWarning;

    private Renderer objectRenderer;
    public float currentEnergy;
    private bool isRenderMaterialActive;
    private void OnEnable()
    {
        ItemManager.OnBattaryUsed += EnergyToMax;
    }
    private void OnDisable()
    {
        ItemManager.OnBattaryUsed -= EnergyToMax;
    }
    private void Start()
    {
        objectRenderer = GetComponent<Renderer>();
        objectRenderer.material = material1; // Start with material 1 (black screen)
        currentEnergy = maxEnergy;
    }
    public void EnergyToMax()
    {
        currentEnergy = maxEnergy;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (!isRenderMaterialActive && currentEnergy >= energyRequirement)
            {
                // If material 1 is active, switch to material 2
                SwitchToMaterial(material2);
            }
            else
            {
                // If material 2 is active, switch to material 1
                SwitchToMaterial(material1);
            }
        }
        UpdateEnergy();
    }

    private void SwitchToMaterial(Material mat)
    {
        if (mat == material2)
        {
            objectRenderer.material = material2;
            isRenderMaterialActive = true;
        }
        else
        {
            objectRenderer.material = material1;
            isRenderMaterialActive = false;
        }
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
                SwitchToMaterial(material1);
            }
        }
        /*
        else
        {
            // Recharge energy when material 1 is active
            currentEnergy += energyRechargeRate * Time.deltaTime;
            currentEnergy = Mathf.Min(currentEnergy, maxEnergy); // Ensure energy doesn't exceed the maximum
        }
        */

        _chargeText.text = "Camera charge: " + Mathf.RoundToInt(currentEnergy) + "%";

        if (currentEnergy < energyRequirement && !_lowChargeWarning.activeSelf) // Red text is displayed if the camera's charge is low
        {
            _lowChargeWarning.SetActive(true);
        }
        else if (currentEnergy > energyRequirement && _lowChargeWarning.activeSelf)
        {
            _lowChargeWarning.SetActive(false);
        }
    }
}
