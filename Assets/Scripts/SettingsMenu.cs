using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    /*public AudioMixer audioMixer;*/
    public Toggle toggle;
    GameObject[] tutorials;

    /*public void SetVolume (float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }*/

    public void Start()
    {
        if (tutorials == null)
        {
            tutorials = GameObject.FindGameObjectsWithTag("tuttext");
        }
    }

    public void SetText ()
    {
        if (toggle.isOn == true)
        {
            Debug.Log("addtext");
            foreach (GameObject tutorial in tutorials)
            {
                tutorial.SetActive(true);
            }
        }
        else if (toggle.isOn == false)
        {
            Debug.Log("offtext");
            foreach (GameObject tutorial in tutorials)
            {
                tutorial.SetActive(false);
            }
        }
    }
}
