using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class throwing_script : MonoBehaviour
{
    public throwing_slider throwing;
    private bool pickedup;
    private float strength;
    public TMP_Text itemName;

    IEnumerator Throw;
    private void Start()
    {
        strength = 0;
    }
    public void ThrowButtonDown()
    {
        pickedup = PlayerMovement.getPickedUp();
        if (pickedup == true)
        {
            //throwing.gameObject.transform.GetChild(0).gameObject.SetActive(true);
            throwing.slider.gameObject.SetActive(true);
            Throw = ThrowStrengthIncrease();
            StartCoroutine(Throw);
            //itemName.text = "";
        }
    }

    public void ThrowButtonUp()
    {
        pickedup = PlayerMovement.getPickedUp();
        if (Throw != null)
        {
          StopCoroutine(Throw);
        }        
        if (pickedup == true)
        {
            throwitem();
            strength = 0;
            throwing.setstrengthvalue(strength);
            //throwing.gameObject.transform.GetChild(0).gameObject.SetActive(false);
            throwing.slider.gameObject.SetActive(false);
        }
    }

    public IEnumerator ThrowStrengthIncrease()
    {
        while (true)
        {
            if (strength >= 0 && strength <= 0.2f)
            {
                throwing.setstrengthvalue(strength);
                strength += 0.1f * Time.deltaTime;
                yield return null;
            }
            else
            {
                break;
            }
        }
    }
    public void throwitem()
    {
        GameObject child = transform.GetChild(2).gameObject;
        child.SetActive(true);

        
        child.transform.parent = null;
        child.GetComponent<Rigidbody>().isKinematic = false;
        child.GetComponent<Collider>().enabled = true;
        child.GetComponent<spinny>().enabled = false;
        Vector3 throwingstrength = (transform.forward + transform.up) * strength;
        child.transform.position = child.transform.position - new Vector3(0, 0.4f) + transform.forward * .15f;
        child.GetComponent<Rigidbody>().AddForce(throwingstrength, ForceMode.Impulse);
        PlayerMovement.setPickedUp(false);
        //itemName.text = "";
    }
}
