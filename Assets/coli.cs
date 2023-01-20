using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coli : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (!hardcode_pog.sinkmoment)
            {
                hardcode_pog.cyl = true;
                gameObject.SetActive(false);
            }
            else
            {
                hardcode_pog.sinkProgress = true;
            }

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
