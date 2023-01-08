using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn : MonoBehaviour
{
    public float time;
    public GameObject[] items;
    public Transform spawns;
    public List<GameObject> itemsSpawnList;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
    }

    private void FixedUpdate()
    {
        if (time > 5)
        {
            int number = Random.Range(0, items.Length);
            itemsSpawnList.Add(Instantiate(items[number], spawns.position, Quaternion.identity, spawns));
            time = 0;
        }
    }
}
