using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class follow_by_offset : MonoBehaviour
{
    public Canvas canvas;
    private Vector3 offset;

    private void Start()
    {
        offset = canvas.transform.position - gameObject.transform.position;
    }
    private void Update()
    {
        canvas.transform.position = gameObject.transform.position + offset;
    }
}
