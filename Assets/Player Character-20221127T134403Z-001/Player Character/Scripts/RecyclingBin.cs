using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecyclingBin : MonoBehaviour
{
    public string Tag;

    private void Start()
    {
        Debug.Log(Tag);
    }
    void OnCollisionEnter(Collision other)//Create an On Trigger function for all colliders with IsTrigger on
    {
        if (other.gameObject.tag == Tag)//If the game object that collides with the IsTrigger collider's Tag is "Delete"
        {
            Debug.Log("Stored " + Tag);
            Destroy(other.gameObject);//Destroy the game object
        }
    }
}
