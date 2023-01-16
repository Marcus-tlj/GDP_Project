using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public GameObject ToTurnOff;
    public GameObject ToTurnOn;
    public void OnClickTest()
    {
        Debug.Log("Clicked");
        ToTurnOn.SetActive(true);
        ToTurnOff.SetActive(false);
    }
}
