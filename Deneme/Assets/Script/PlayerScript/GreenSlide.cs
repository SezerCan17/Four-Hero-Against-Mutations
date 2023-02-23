using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GreenSlide : MonoBehaviour
{
    public Slider slider2;

    public void SetMaxObjects(int maxObjects)
    {
        slider2.maxValue = maxObjects;
        slider2.value = 0;
    }

    public void SetObjects(int maxobjects)
    {
        slider2.value = maxobjects;
    }
}
