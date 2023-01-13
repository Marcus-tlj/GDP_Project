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
            Pm.wash = false;
            transform.GetChild(0).gameObject.SetActive(false);

        }

    }
}
