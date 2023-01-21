using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Papere : MonoBehaviour
{
    //reference for the item class
    private Item item;
    //reference for the Multiple_Material class which is on certain items
    private MeshRenderer mesh_renderer;

    public Texture dirtyGlass;
    public Texture dirtyMetal;
    public Texture dirtyPlastic;
    public Texture dirtyPaper;
    public Texture dirtyJunk;

    // Start is called before the first frame update
    void Start()
    {
        Outline outline;
        Rigidbody rb;

        MeshCollider meshCollide = GetComponent<MeshCollider>();

        item = new Item(Item.itemMaterial.paper, false);

        GameObject _item = Instantiate(item.itemModel, transform.position, transform.rotation);
        _item.transform.parent = gameObject.transform;

        if (item.isDirty && item.material == Item.itemMaterial.glass)
        {
            _item.GetComponent<Renderer>().material.SetTexture("_MainTex", dirtyGlass);
            gameObject.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
        }
        else
        {
            gameObject.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
        }
        if (item.isDirty && item.material == Item.itemMaterial.metal)
        {
            _item.GetComponent<Renderer>().material.SetTexture("_MainTex", dirtyMetal);
            gameObject.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        }
        else
        {
            gameObject.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        }
        if (item.isDirty && item.material == Item.itemMaterial.plastic)
        {
            _item.GetComponent<Renderer>().material.SetTexture("_MainTex", dirtyPlastic);
            gameObject.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        }
        else
        {
            gameObject.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        }
        if (item.isDirty && item.material == Item.itemMaterial.paper)
        {
            _item.GetComponent<Renderer>().material.SetTexture("_MainTex", dirtyPaper);
            gameObject.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
        }
        else
        {
            gameObject.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
        }
        if (item.isDirty && item.material == Item.itemMaterial.junk)
        {
            _item.GetComponent<Renderer>().material.SetTexture("_MainTex", dirtyJunk);
            gameObject.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        }
        else
        {
            gameObject.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        }



        meshCollide.sharedMesh = item.itemModel.GetComponent<MeshFilter>().sharedMesh;

        gameObject.tag = item.material.ToString();

        rb = GetComponent<Rigidbody>();

        rb.mass = 0.1f;

        Debug.Log("Material: " + item.material + "," + "isDirty: " + item.isDirty);

    }
}
