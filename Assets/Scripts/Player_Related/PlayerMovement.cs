using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{

    public bool isMoving;

    public GameObject washingParticle;

    public FixedJoystick mJoystick;

    Rigidbody r;
    public bool pickedup = false;
    Animator anim;
    spawn m_spawn;
    public float strength;
    public throwingStrength throwing;
    public Canvas canvas;
    public Button throwButton;
    public bool isPressed;

    public static float playerSpeed;

    public float walkSpeed = 1.5f;
    public float sprintSpeed = 2.5f;
    public float dashDelay = 20f;
    public float speedMultiplier = 5;
    public float dashForce = 2;

    float dashCooldown;

    public GameObject sink;
    public bool wash;
    public static Vector3 MoveDirection;

    IEnumerator Throw;

    void Start()
    {
        GameObject spawner = GameObject.FindGameObjectWithTag("spawn");
        m_spawn = spawner.GetComponent<spawn>();
        strength = 0;

        anim = GetComponent<Animator>();
        r = GetComponent<Rigidbody>();
        r.freezeRotation = true;
        wash = false;
    }

    private void Update()
    {
        canvas.transform.rotation = Quaternion.Euler(transform.eulerAngles.x,0,transform.eulerAngles.z);
    }

    void FixedUpdate()
    {
        //outlinesink();
        //outlineobjects();

        if (!wash)
        {
            movePlayer();
        }
        sprint();
    }
    public void washing()
    {
        RaycastHit hit;
        Vector3 offset = new Vector3(0, .1f, 0);
        if (Physics.SphereCast(transform.position + offset, .05f, transform.forward, out hit, .15f) || Physics.SphereCast(transform.position + new Vector3(0, .015f, 0), .01f, transform.forward, out hit, .15f))
        {
            if (hit.collider.CompareTag("sink"))
            {
                GameObject sinkbar = hit.collider.transform.GetChild(0).gameObject;
                sinkbar.SetActive(true);
                hit.collider.GetComponent<SinkScript>().enabled = true;
                sinkbar.gameObject.GetComponentInChildren<SinkBar>().setwashingtime(0f);
                hit.collider.GetComponent<SinkScript>().washingtime = 0f;
                wash = true;
            }
        }
    }
    public void ThrowButtonDown()
    {      
        if (pickedup == true)
        {
            Throw = ThrowStrengthIncrease();
            StartCoroutine(Throw);
        }
    }

    public void ThrowButtonUp()
    {
        StopCoroutine(Throw);
        if (pickedup == true)
        {
            throwitem();
            strength = 0;
            throwing.setstrengthvalue(strength);
            throwing.gameObject.transform.GetChild(0).gameObject.SetActive(false);
        }
    }

    public IEnumerator ThrowStrengthIncrease()
    {
        while (true)
        {
            if (strength >= 0 && strength <= 0.2f)
            {
                throwing.gameObject.transform.GetChild(0).gameObject.SetActive(true);
                throwing.setstrengthvalue(strength);
                strength += 0.1f * Time.deltaTime;
                yield return null;
            }
            else
            {
                break;
            }           
        }
    }
    public void throwitem()
    {
        GameObject child = transform.GetChild(2).gameObject;
        child.SetActive(true);
        child.transform.parent = null;
        Vector3 throwingstrength = (transform.forward + transform.up) * strength;
        child.GetComponent<Rigidbody>().AddForce(throwingstrength, ForceMode.Impulse);
        pickedup=false;

    }

    public void outlinesink()
    {
        RaycastHit hit;
        Vector3 offset = new Vector3(0, .1f, 0);
        sink.GetComponent<Outline>().enabled = false;
        if (Physics.SphereCast(transform.position + offset, .05f, transform.forward, out hit, .15f)){
            if(hit.collider.CompareTag("sink"))
            {
                hit.collider.GetComponent<Outline>().enabled = true;
            }

        }

    }

    public void outlineobjects()    
    {
        List<GameObject> itemlist = m_spawn.itemsSpawnList;
        RaycastHit hit;
        Vector3 offset = new Vector3(0, .1f, 0);

        for (int i = 0; i < itemlist.Count; i++)
        {
            if (m_spawn.itemsSpawnList[i] != null)
            {
                m_spawn.itemsSpawnList[i].transform.GetChild(0).GetComponent<Outline>().enabled = false;
                if (Physics.SphereCast(transform.position + offset, .05f, transform.forward, out hit, .15f) || Physics.SphereCast(transform.position + new Vector3(0, .015f, 0), .01f, transform.forward, out hit, .15f))
                {
                    if (hit.collider.CompareTag("plastic") || hit.collider.CompareTag("glass") || hit.collider.CompareTag("metal") || hit.collider.CompareTag("paper") || hit.collider.CompareTag("junk"))
                    {
                        hit.collider.transform.GetChild(0).GetComponent<Outline>().enabled = true;
                    }

                }
            }
        }
    }
    public void grabitem()
    {
        RaycastHit hit;
        List<GameObject> itemlist = m_spawn.itemsSpawnList;
        Vector3 offset = new Vector3(0, .1f, 0);
        for(int i = 0; i < itemlist.Count; i++)
        {
            if (m_spawn.itemsSpawnList[i] != null)
            {
                if (Physics.SphereCast(transform.position+offset,.05f,transform.forward,out hit,2f) || Physics.SphereCast(transform.position+ new Vector3(0,.015f,0), .01f, transform.forward, out hit, .15f))
                {                    
                    if (hit.collider.CompareTag("plastic")|| hit.collider.CompareTag("glass")|| hit.collider.CompareTag("metal") || hit.collider.CompareTag("paper") || hit.collider.CompareTag("junk"))
                    {

                        hit.collider.gameObject.transform.parent = transform;
                        hit.collider.gameObject.SetActive(false);

                        pickedup = true;
                    }
                }
            }
        }

    }

    public void movePlayer() //player movement with rigidbody
    {


        float zMovement = 2.0f * mJoystick.Horizontal;
        float xMovement = 2.0f * mJoystick.Vertical;

        Vector3 lookDirection = new Vector3(zMovement, 0.0f, xMovement);
        transform.LookAt(lookDirection + transform.position);

        MoveDirection = Vector3.forward * xMovement + Vector3.right * zMovement;

        r.velocity = MoveDirection.normalized * playerSpeed * speedMultiplier;

        if (r.velocity.sqrMagnitude > 0)
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }

        //plays animation according to player's movement
        anim.SetFloat("MoveSpeedX", Mathf.Abs(xMovement));
        anim.SetFloat("MoveSpeedZ", Mathf.Abs(zMovement));
        //anim.SetFloat("speed", MoveDirection.magnitude);
    }

    public void sprint() //increases player speed when sprint button is pressed
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            playerSpeed = sprintSpeed;
        }
        else
        {
            playerSpeed = walkSpeed;
        }
    }

    public void pickItem()
    {
        Debug.Log("pickup");
        if (pickedup == false)
            {
                anim.SetTrigger("pickup");
                grabitem();
            }
        else if (pickedup == true)
            {
                GameObject child = transform.GetChild(2).gameObject;
                child.SetActive(true);
                child.transform.parent = null;
                child.transform.position = transform.position + transform.forward * .15f;

                anim.SetTrigger("dropped");
                pickedup = false;

        }
    }

    public void chargeItem()
    {
        {
            if (pickedup == true)
            {

                if (strength >= 0 && strength <= 0.2f)
                {
                    throwing.gameObject.transform.GetChild(0).gameObject.SetActive(true);
                    throwing.setstrengthvalue(strength);
                    strength += 0.1f * Time.deltaTime;

                }
            }
        }
    }

    public void throwPower()
    {
        {
            if (pickedup == true)
            {
                throwitem();
                strength = 0;
                throwing.setstrengthvalue(strength);
                throwing.gameObject.transform.GetChild(0).gameObject.SetActive(false);
            }
        }
    }
}