using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SinkBar : MonoBehaviour
{
    public Slider slider;

    public void setmaxwashingTime(float maxStrength)
    {
        slider.maxValue = maxStrength;

    }

    public void setwashingtime(float strength)
    {
        slider.value = strength;
    }
}
