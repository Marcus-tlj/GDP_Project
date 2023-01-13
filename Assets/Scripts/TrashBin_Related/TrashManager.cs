using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashManager : MonoBehaviour
{
    int trashbinnumber = 0;
    public List<GameObject> trashBin;
    public float timer;
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {

        if (trashbinnumber < 4)
        {
            timer += Time.deltaTime;
            for ( int i = 0; i < trashBin.Count; i++)
        {
            
            if (timer > 5)
            {

                    trashBin[trashbinnumber].GetComponent<TrashBin_Movements>().enabled = true;
                    trashbinnumber++;
                    timer = 0;
                
                }
            }
        }
    }

}
