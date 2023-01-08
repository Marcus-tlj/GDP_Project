using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecyclingBin : MonoBehaviour
{
    public string Tag;
    public int bin_id;

    private void Start()
    {
        //Debug.Log(Tag);
    }
    void OnCollisionEnter(Collision other)//Create an On Trigger function for all colliders with IsTrigger on
    {
        //Tag is a string that is set in the inspector, it would be paper, plastic, metal etc
        //Essentially this is the check for the correct or wrong trash being thrown inside 

        //This Code would run if the player throws the Correct piece of Trash into the bin
        if (other.gameObject.tag == Tag)
        {
            //Debug.Log("Stored " + Tag);
            //Destroy the game object so that it is no longer visible
            Destroy(other.gameObject);
            points.IncrementStreak();
            points.IncrementBinCleanCount(bin_id);
            points.ChangePoints(Global_Variables.PtsGainForCorrectDisposal);
        }
        else
        {
            Destroy(other.gameObject);
            points.ResetStreak();
            points.ResetBinCleanCount(bin_id);
            points.Contaminated(bin_id);
        }
    }
}
