using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GreenBar : MonoBehaviour
{
    public Slider greenSlider;
    public void SetMaxHealth(int health)
    {
        greenSlider.maxValue = health;
        greenSlider.value = 0;
    }

    public void SetHealth(int health)
    {
        greenSlider.value = health;
    }
}
