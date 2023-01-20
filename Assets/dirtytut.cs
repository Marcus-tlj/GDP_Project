using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dirtytut : MonoBehaviour
{
    //reference for the item class
    public Item item;
    //reference for the Multiple_Material class which is on certain items
    private Multiple_Materials m_materials;
    private MeshRenderer mesh_renderer;

    public PlayerMovement pm;

    public Texture dirtyPlastic;


    public Texture cleanPlastic;

    // Start is called before the first frame update
    void Start()
    {
        Outline outline;
        Rigidbody rb;

        MeshCollider meshCollide = GetComponent<MeshCollider>();

        item = new Item(Item.itemMaterial.plastic, true);

        GameObject _item = Instantiate(item.itemModel, transform.position, transform.rotation);
        _item.transform.parent = gameObject.transform;

        if (item.isDirty && item.material == Item.itemMaterial.plastic)
        {
            _item.GetComponent<Renderer>().material.SetTexture("_MainTex", dirtyPlastic);
            gameObject.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        }
        if (pm.doneWashing)
        {
            item.isDirty = false;
            _item.GetComponent<Renderer>().material.SetTexture("_MainTex", cleanPlastic);
            gameObject.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        }
      



        meshCollide.sharedMesh = item.itemModel.GetComponent<MeshFilter>().sharedMesh;

        gameObject.tag = item.material.ToString();

        rb = GetComponent<Rigidbody>();

        rb.mass = 0.1f;

        Debug.Log("Material: " + item.material + "," + "isDirty: " + item.isDirty);

    }

    // Update is called once per frame
    void Update()
    {
        //This Statement would only trigger for certain models because some of them do not have clean/dirty textures, only 1
        if (m_materials != null)
        {
            if (item.isDirty == true) //Item is Dirty
            {
                mesh_renderer.material = m_materials.Texture_Dirty;
            }
            else if (item.isDirty == false) //Item is Clean
            {
                mesh_renderer.material = m_materials.Texture_Clean;
            }
        }
    }
}