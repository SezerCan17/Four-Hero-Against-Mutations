using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public Slider slider2;

    public void SetMaxHealth(int health)
    {
        slider.maxValue= health;
        slider.value= 0;
    }

    public void SetHealth(int health)
    {
        slider.value= health;  
    }

    public void SetMaxObjects(int maxObjects)
    {
        slider2.maxValue= maxObjects;
        slider2.value= 0;
    }

    public void SetObjects(int maxobjects)
    {
        slider2.value= maxobjects;
    }
}
