using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UImanager : MonoBehaviour
{

    [SerializeField] private Image healthGlobe, manaGlobe;
    [SerializeField] private Slider xpSlider;
    [SerializeField] private PlayerHealth playerHealth;
    
    void Update()
    {
        healthGlobe.fillAmount = playerHealth.GetHealthRatio();
    }
}
