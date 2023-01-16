using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{

    // enum containing all item materials
    public enum itemMaterial
    {
        metal,
        paper,
        plastic,
        glass,
        junk
    }

    public GameObject[] metalMeshes = Resources.LoadAll<GameObject>("Items/Metal");
    public GameObject[] paperMeshes = Resources.LoadAll<GameObject>("Items/Paper");
    public GameObject[] plasticMeshes = Resources.LoadAll<GameObject>("Items/Plastic");
    public GameObject[] glassMeshes = Resources.LoadAll<GameObject>("Items/Glass");
    public GameObject[] junkMeshes = Resources.LoadAll<GameObject>("Items/Junk");

    public itemMaterial material; // item material of object
    public bool isDirty; // dirtiness of item
    public GameObject itemModel; // mesh of item
    

    // set item Property
    public Item(itemMaterial material, bool dirty)
    {
        this.isDirty = dirty;
        this.material = material;

        if (material == itemMaterial.metal)
        {
            int ranMesh = Random.Range(0, metalMeshes.Length);
            this.itemModel = metalMeshes[ranMesh];
        }
        else if (material == itemMaterial.paper)
        {
            int ranMesh = Random.Range(0, paperMeshes.Length);
            this.itemModel = paperMeshes[ranMesh];
        }
        else if (material == itemMaterial.plastic)
        {
            int ranMesh = Random.Range(0, plasticMeshes.Length);
            this.itemModel = plasticMeshes[ranMesh];
        }
        else if (material == itemMaterial.glass)
        {
            int ranMesh = Random.Range(0, glassMeshes.Length);
            this.itemModel = glassMeshes[ranMesh];
        }
        else 
        {
            int ranMesh = Random.Range(0, junkMeshes.Length);
            this.itemModel = junkMeshes[ranMesh];
        }
    }
    
    // Randomized item properties when no overide is given
    public Item()
    {
        int dirtyRan = Random.Range(0, 2); // random number from 0 - 1 -- used to randomize item dirtiness
        int materialRan = Random.Range(0, 5); // random number from 0 - 4 -- used to randomize material of item

        // randomize dirtiness

        if (dirtyRan == 0)
        {
            this.isDirty = false;
        }
        else
        {
            this.isDirty = true;
        }

        // randomize material

        if (materialRan == 0)
        {
            this.material = itemMaterial.metal;

            int ranMesh = Random.Range(0, metalMeshes.Length);
            this.itemModel = metalMeshes[ranMesh];
        }
        else if (materialRan == 1)
        {
            this.material = itemMaterial.paper;

            int ranMesh = Random.Range(0, paperMeshes.Length);
            this.itemModel = paperMeshes[ranMesh];
        }
        else if (materialRan == 2)
        {
            this.material = itemMaterial.plastic;

            int ranMesh = Random.Range(0, plasticMeshes.Length);
            this.itemModel = plasticMeshes[ranMesh];
        }
        else if (materialRan == 3)
        {
            this.material = itemMaterial.glass;

            int ranMesh = Random.Range(0, glassMeshes.Length);
            this.itemModel = glassMeshes[ranMesh];
        }
        else
        {
            this.material = itemMaterial.junk;

            int ranMesh = Random.Range(0, junkMeshes.Length);
            this.itemModel = junkMeshes[ranMesh];
        }


    }
}
