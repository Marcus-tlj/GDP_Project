using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class ItemHandler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Outline outline;
        Rigidbody rb;

        MeshCollider meshCollide = GetComponent<MeshCollider>();

        Item item = new Item();

        GameObject _item =  Instantiate(item.itemModel, transform.position, transform.rotation);
        _item.transform.parent = gameObject.transform;

        gameObject.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);

        //_item.AddComponent<Outline>();

        //outline = _item.GetComponent<Outline>();

        //outline.OutlineColor = Color.red;

        meshCollide.sharedMesh = item.itemModel.GetComponent<MeshFilter>().sharedMesh;

        gameObject.tag = item.material.ToString();

        rb = GetComponent<Rigidbody>();

        rb.mass = 0.1f;

        Debug.Log("Material: " + item.material + "," + "isDirty: " + item.isDirty);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
