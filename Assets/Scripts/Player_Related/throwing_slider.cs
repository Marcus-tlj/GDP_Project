using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class throwing_slider : MonoBehaviour
{
    public Slider slider;

    public void setmaxstrength(float maxStrength)
    {
        slider.maxValue = maxStrength;

    }

    public void setstrengthvalue(float strength)
    {
        slider.value = strength;
    }

}
