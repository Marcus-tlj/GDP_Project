using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class hardcode_pog : MonoBehaviour
{
    public GameObject itemthingy;
    public GameObject bin;
    public GameObject player;
    GameObject gui;
    public PlayerMovement pm;
    public TextMeshProUGUI move;
    public TextMeshProUGUI stuff;
    public UnityEngine.UI.Image blur;
    public float timer;
    public float timer2;
    public float timer3;
    public GameObject cylinder;
    public CameraMovement cameraMovement;
    public GameObject pickup;
    public TextMeshProUGUI throwit;

    public GameObject moveButton;

    public GameObject throwButton;
    public TextMeshProUGUI throwtext;

    public GameObject trashbin;

    public GameObject yellow;
    public GameObject red;
    public GameObject green;
    public GameObject junk;

    public GameObject pos1;
    public GameObject pos2;

    public GameObject paper;
    public GameObject glass;
    public GameObject plastic;
    public GameObject metal;
    public GameObject junkb;

    public Texture dirtyGlass;
    public Texture dirtyMetal;
    public Texture dirtyPlastic;
    public Texture dirtyPaper;
    public Texture dirtyJunk;

    public GameObject sink;

    public static bool sinkmoment = false;
    public static bool sinkProgress = false;

    public static bool cyl = false;
    public static bool it = false;

    bool done1 = false;
    bool movetut = false;
    bool backtoplayer = false;

    float t;

    public GameObject washbutton;
    public TextMeshProUGUI washtext;

    public GameObject dirtythingy;

    public GameObject item3;

    public ConveyorMovement cm1;
    public ConveyorMovement cm2;


    // Start is called before the first frame update
    void Start()
    {
        cm1.speed = 0;
        cm2.speed= 0;

        
            
        


        //itemthingy.transform.GetComponent<ItemHandler>().item.material = Item.itemMaterial.paper;
        //itemthingy.transform.GetComponent<ItemHandler>().item.isDirty = false; 
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
        if (!pm.isMoving && !movetut)
        {
            throwit.enabled = false;
            itemthingy.transform.GetChild(0).GetComponent<Renderer>().enabled = false;
            dirtythingy.transform.GetChild(0).GetComponent<Renderer>().enabled = false;
            item3.GetComponent<Renderer>().enabled = false;
        }
      

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
                itemthingy.transform.GetChild(0).GetComponent<Renderer>().enabled = true;
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
            if (timer2 == 0)
            {
                blur.enabled = false;
                stuff.enabled = false;
                it = true;
                bin.SetActive(true);
                cameraMovement.player = bin.transform;
                throwit.enabled = true;
                blur.enabled = true;
                if (!done1)
                {
                    timer = 0;
                }
                done1 = true;
            }

        }

        if (done1)
        {
            timer += Time.deltaTime;
            if (timer >= 2)
            {
                cameraMovement.player = player.transform;
                blur.enabled = false;
                throwit.enabled = false;
                throwtext.enabled = true;
                throwButton.SetActive(true);

            }
        }

        if (done1 && RecyclingBin.thrown == 1 && !pm.doneWashing)
        {
            throwtext.enabled = false;
            trashbin.SetActive(true);

            throwButton.SetActive(false);
            pickup.SetActive(false);
            moveButton.SetActive(false);

            yellow.SetActive(true);
            red.SetActive(true);
            green.SetActive(true);
            junkb.SetActive(true);


            throwit.enabled = true;
            throwit.color = Color.red;
            throwit.text = "Put items in their corresponding bins";

            cameraMovement.player = pos1.transform;

            glass.SetActive(true);
            metal.SetActive(true);
            paper.SetActive(true);
            plastic.SetActive(true);
            junk.SetActive(true);

            timer2 += Time.deltaTime;

            if (timer2 >= 3)
            {
                //pm.pickedup = false;
                paper.GetComponent<Renderer>().material.SetTexture("_MainTex", dirtyPaper);
                plastic.GetComponent<Renderer>().material.SetTexture("_MainTex", dirtyPlastic);
                glass.GetComponent<Renderer>().material.SetTexture("_MainTex", dirtyGlass);
                metal.GetComponent<Renderer>().material.SetTexture("_MainTex", dirtyMetal);
                junk.GetComponent<Renderer>().material.SetTexture("_MainTex", dirtyJunk);

                throwit.color = Color.red;
                throwit.text = "Some items can be dirty."; 
            }
            if (timer2 >= 6)
            {
                sink.SetActive(true);
                throwit.text = "Dirty items must be washed first";
                cameraMovement.player = sink.transform;
            }
            if (timer2 >= 9)
            {
                glass.SetActive(false);
                metal.SetActive(false);
                paper.SetActive(false);
                plastic.SetActive(false);
                junk.SetActive(false);

                throwButton.SetActive(true);
                pickup.SetActive(true);
                moveButton.SetActive(true);

                dirtythingy.transform.GetChild(0).GetComponent<Renderer>().enabled = true;
                cameraMovement.player = dirtythingy.transform;

                throwit.text = "Pick up the dirty item";
            }
            if (timer2 >= 11)
            {
                throwit.enabled = false;
                cameraMovement.player = player.transform;
            }

            if (timer2 > 11 && pm.pickedup && !sinkProgress)
            {
                throwit.enabled = true;
                throwit.text = "go to the sink";
                sinkmoment = true;
            }


        }

        if (sinkProgress)
        {
            throwit.enabled = false;
            washbutton.SetActive(true);
        }

        if (pm.doneWashing)
        {
            throwtext.enabled = false;
            throwit.enabled = true;
            washtext.enabled = false;
            throwit.text = "Throw it into the correct bin";
        }

        if (RecyclingBin.thrown == 2)
        {
            timer3 += Time.deltaTime;
            cm1.speed = 0.1f;
            cm2.speed = 0.1f;

            cameraMovement.player = item3.transform;
            item3.GetComponent<Renderer>().enabled = true;

            throwit.text = "Items will move down the conveyor belt";

            if (timer3 >= 3)
            {
                throwit.text = "Do not let items go into the incinerator";
                cameraMovement.player = pos2.transform;
            }

            if (timer3 >= 6)
            {
                throwit.color = Color.green;
                throwit.text = "Tutorial Complete!";
            }
            if (timer3 >= 9)
            {
                SceneManager.LoadScene("game_scene", LoadSceneMode.Single);
            }
        }
    }
}
