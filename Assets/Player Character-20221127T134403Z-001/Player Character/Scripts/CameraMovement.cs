using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    public Transform player;
    public float cameraHeight = 2;
    public float xOffset = 0;
    public float zOffset = 0;
    public float smoothTime = 0.4f;
    Vector3 velocity = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerPos = new Vector3(player.position.x+xOffset, cameraHeight, player.position.z+zOffset);

        transform.position = Vector3.SmoothDamp(gameObject.transform.position, playerPos, ref velocity, smoothTime);
    }
}
