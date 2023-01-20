using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinkScript : MonoBehaviour
{
    public SinkBar sinkbar;
    public float washingtime;
    public PlayerMovement Pm;
   

    // Start is called before the first frame update
    void Start()
    {
        sinkbar.setmaxwashingTime(5f);
        sinkbar.setwashingtime(0);
    }

    // Update is called once per frame
    void Update()
    {
        washingtime+= Time.deltaTime;
        sinkbar.setwashingtime(washingtime);
        if(washingtime > 5)
        {
            if (Pm.wash) { 
            }
            transform.GetChild(0).gameObject.SetActive(false);
            //if (Pm.pickedup)
            //{
               // if (Pm.heldObject.transform.GetChild(0).GetComponent<ItemHandler>() != null)
               // {
                //    Pm.heldObject.transform.GetChild(0).GetComponent<ItemHandler>().item.isDirty = false;
                //}
                //if (Pm.heldObject.transform.GetChild(0).GetComponent<dirtytut>() != null)
                //{
                //    Pm.heldObject.transform.GetChild(0).GetComponent<dirtytut>().item.isDirty = false;
               // }

            //}
            
            Pm.wash = false;
            
            
        }

    }
}
