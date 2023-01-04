using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyItems : MonoBehaviour
{
    public int maxtrash = 0;
    public int currenttrsh;
    spawn m_spawn;
    public burntrash trashbarcount;
    private void Start()
    {
        trashbarcount.setmaxhealth(20);
        GameObject spawner = GameObject.FindGameObjectWithTag("spawn");
        m_spawn = spawner.GetComponent<spawn>();
    }
    
    private void increasetrashcount(int increase)
    {
        currenttrsh += increase ;
        trashbarcount.settrashcount(currenttrsh);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Player")
        {
            increasetrashcount(1);
            m_spawn.itemsSpawnList.Remove(other.gameObject);
            Destroy(other.gameObject);

        }
    }
}
