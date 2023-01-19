using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickdone : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "glass" || other.gameObject.tag == "paper" || other.gameObject.tag == "plastic" || other.gameObject.tag == "metal" || other.gameObject.tag == "junk")
        {
            hardcode_pog.it = true;
            gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
