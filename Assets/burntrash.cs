using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class burntrash : MonoBehaviour
{
    public Slider slider;

    public void setmaxhealth(int trashedburn)
    {
        slider.maxValue = trashedburn;

    }

    public void settrashcount(int trash)
    {
        slider.value = trash;
    }

    
}
