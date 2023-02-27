using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GreenBar : MonoBehaviour
{
    public Slider greenSlider;
    public void SetMaxHealth(int obj)
    {
        greenSlider.maxValue = 3;
        greenSlider.value = 0;
    }

    public void SetHealth(int obj)
    {
        greenSlider.value = obj;
    }
}
