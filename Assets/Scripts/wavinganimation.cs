using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wavinganimation : MonoBehaviour
{
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("wave",true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
