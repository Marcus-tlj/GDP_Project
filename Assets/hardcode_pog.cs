using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class hardcode_pog : MonoBehaviour
{
    //public GameObject itemthingy;
    public GameObject bin;
    public GameObject player;
    GameObject gui;
    public PlayerMovement pm;
    public TextMeshProUGUI move;
    public TextMeshProUGUI stuff;
    public UnityEngine.UI.Image blur;
    public float timer;
    public GameObject cylinder;
    public CameraMovement cameraMovement;
    public GameObject pickup;
    public TextMeshProUGUI throwit;

    public static bool cyl = false;
    public static bool it = false;

    bool done1 = false;
    bool movetut = false;
    bool backtoplayer = false;



    // Start is called before the first frame update
    void Start()
    {
        throwit.enabled = false;
        //stuff.enabled = false;
        //player = GameObject.Find("PlayerCharacter");
        //gui = GameObject.Find("GUI_Canvas");

        //GameObject moveText = GameObject.Find("move text");
        //GameObject joystick = GameObject.Find("Fixed Joystick");

        //gui.SetActive(false);
        //joystick.SetActive(true);
        //moveText.SetActive(true);
        //player.GetComponent<PlayerMovement>().enabled= false;
    }

    // Update is called once per frame
    void Update()
    {


        if (pm.isMoving == true)
        {
            timer += Time.deltaTime;
            if (timer >= 1 && !movetut)
            {
                move.enabled = false;
                blur.enabled = false;
                timer = 0;
                movetut = true;
                cylinder.SetActive(true);
                cameraMovement.player = cylinder.transform;
                //itemthingy.SetActive(true);
            }



        }

        if (movetut && !backtoplayer)
        {
            timer += Time.deltaTime;
            if (timer >= 2)
            {
                cameraMovement.player = player.transform;
                backtoplayer = true;
                timer= 0;
            }
        }

        if (backtoplayer && cyl)
        {
            cameraMovement.player = player.transform;
            //blur.enabled = true;
            pickup.SetActive(true);
        }

        if (pm.pickedup || it)
        {
            blur.enabled = false;
            stuff.enabled = false;
            it= true;
            bin.SetActive(true);
            cameraMovement.player = bin.transform;
            throwit.enabled = true;
            blur.enabled = true;
            if (!done1)
            {
                timer = 0;
            }
            done1= true;
        }

        if (done1)
        {
            timer += Time.deltaTime;
            if (timer >= 4)
            {
                cameraMovement.player = player.transform;
                blur.enabled = false;
                throwit.enabled = false;

            }
        }
    }
}
