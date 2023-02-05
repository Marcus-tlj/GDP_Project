using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class ItemHandler : MonoBehaviour
{
    //reference for the item class
    public Item item;
    private MeshRenderer mesh_renderer;

    public Texture dirtyGlass;
    public Texture dirtyMetal;
    public Texture dirtyPlastic;
    public Texture dirtyPaper;
    public Texture dirtyJunk;

    public Texture cleanGlass;
    public Texture cleanMetal;
    public Texture cleanPlastic;
    public Texture cleanPaper;
    public Texture cleanJunk;

    GameObject _item;

    // Start is called before the first frame update
    void Start()
    {
        Outline outline;
        Rigidbody rb;

        MeshCollider meshCollide = GetComponent<MeshCollider>();

        item = new Item();

        _item = Instantiate(item.itemModel, transform.position, transform.rotation);
        _item.transform.parent = gameObject.transform;

        if (item.isDirty && item.material == Item.itemMaterial.glass)
        {
            _item.GetComponent<Renderer>().material.SetTexture("_MainTex", dirtyGlass);
            gameObject.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
        }
        if (!item.isDirty && item.material == Item.itemMaterial.glass)
        {
            _item.GetComponent<Renderer>().material.SetTexture("_MainTex", cleanGlass);
            gameObject.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
        }

        if (item.isDirty && item.material == Item.itemMaterial.metal)
        {
            _item.GetComponent<Renderer>().material.SetTexture("_MainTex", dirtyMetal);
            gameObject.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        }
        if (!item.isDirty && item.material == Item.itemMaterial.metal)
        {
            _item.GetComponent<Renderer>().material.SetTexture("_MainTex", cleanMetal);
            gameObject.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        }

        if (item.isDirty && item.material == Item.itemMaterial.plastic)
        {
            _item.GetComponent<Renderer>().material.SetTexture("_MainTex", dirtyPlastic);
            gameObject.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        }
        if (!item.isDirty && item.material == Item.itemMaterial.plastic)
        {
            _item.GetComponent<Renderer>().material.SetTexture("_MainTex", cleanPlastic);
            gameObject.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        }

        if (item.isDirty && item.material == Item.itemMaterial.paper)
        {
            _item.GetComponent<Renderer>().material.SetTexture("_MainTex", dirtyPaper);
            gameObject.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        }
        if (!item.isDirty && item.material == Item.itemMaterial.paper)
        {
            _item.GetComponent<Renderer>().material.SetTexture("_MainTex", cleanPaper);
            gameObject.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        }

        if (item.isDirty && item.material == Item.itemMaterial.junk)
        {
            _item.GetComponent<Renderer>().material.SetTexture("_MainTex", dirtyJunk);
            gameObject.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        }
        if (!item.isDirty && item.material == Item.itemMaterial.junk)
        {
            _item.GetComponent<Renderer>().material.SetTexture("_MainTex", cleanJunk);
            gameObject.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        }

        meshCollide.sharedMesh = item.itemModel.GetComponent<MeshFilter>().sharedMesh;

        gameObject.tag = item.material.ToString();

        rb = GetComponent<Rigidbody>();

        rb.mass = 0.1f;

        Debug.Log("Material: " + item.material + "," + "isDirty: " + item.isDirty);
        
    }

    private void Update()
    {
       // UpdateTexture(gameObject.transform.GetChild(0).gameObject);
    }

    void UpdateTexture(GameObject _item)
    {
        if (item.isDirty && item.material == Item.itemMaterial.glass)
        {
            _item.GetComponent<Renderer>().material.SetTexture("_MainTex", dirtyGlass);
        }
        if (!item.isDirty && item.material == Item.itemMaterial.glass)
        {
            _item.GetComponent<Renderer>().material.SetTexture("_MainTex", cleanGlass);
        }

        if (item.isDirty && item.material == Item.itemMaterial.metal)
        {
            _item.GetComponent<Renderer>().material.SetTexture("_MainTex", dirtyMetal);
        }
        if (!item.isDirty && item.material == Item.itemMaterial.metal)
        {
            _item.GetComponent<Renderer>().material.SetTexture("_MainTex", cleanMetal);
        }

        if (item.isDirty && item.material == Item.itemMaterial.plastic)
        {
            _item.GetComponent<Renderer>().material.SetTexture("_MainTex", dirtyPlastic);
        }
        if (!item.isDirty && item.material == Item.itemMaterial.plastic)
        {
            _item.GetComponent<Renderer>().material.SetTexture("_MainTex", cleanPlastic);
        }

        if (item.isDirty && item.material == Item.itemMaterial.paper)
        {
            _item.GetComponent<Renderer>().material.SetTexture("_MainTex", dirtyPaper);
        }
        if (!item.isDirty && item.material == Item.itemMaterial.paper)
        {
            _item.GetComponent<Renderer>().material.SetTexture("_MainTex", cleanPaper);
        }

        if (item.isDirty && item.material == Item.itemMaterial.junk)
        {
            _item.GetComponent<Renderer>().material.SetTexture("_MainTex", dirtyJunk);
        }
        if (!item.isDirty && item.material == Item.itemMaterial.junk)
        {
            _item.GetComponent<Renderer>().material.SetTexture("_MainTex", cleanJunk);
        }
    }
}
