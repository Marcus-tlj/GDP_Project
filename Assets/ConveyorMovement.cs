using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorMovement : MonoBehaviour
{
    public float speed;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        
        Vector3 pos = rb.position;
        rb.position += transform.right * speed * Time.deltaTime;
        rb.MovePosition(pos);

    }

 
}
