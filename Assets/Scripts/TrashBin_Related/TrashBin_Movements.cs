using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashBin_Movements : MonoBehaviour
{
    Rigidbody rb;
    RaycastHit hit;
    public GameObject character;
    // Start is called before the first frame update
    void Start()
    {
         rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        rb.transform.position += transform.forward * .1f * Time.deltaTime;
        if (Physics.Raycast( transform.position, character.transform.position + new Vector3(0, .2f, 0), out hit)) {
            print(hit.collider.tag);    
            if (!hit.collider.CompareTag("Player"))
            {
                transform.eulerAngles = ;
            }
}

    }
}
