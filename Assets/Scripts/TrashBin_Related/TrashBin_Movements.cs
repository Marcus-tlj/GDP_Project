using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashBin_Movements : MonoBehaviour
{
    Rigidbody rb;
    RaycastHit hit;
    public float time;
    float speed = .1f;
    // Start is called before the first frame update
    void Start()
    {
         rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        transform.position += transform.forward * speed * Time.deltaTime;
        if (transform.localPosition.z >= 1)
        {

            transform.Rotate(0,180,0);
        }
        if (transform.localPosition.z <= 0 )
        {

            transform.Rotate(0, 180, 0);
        }
        if(time > 10)
        {
            speed += .01f;
            time = 0;
        }
    }


}
