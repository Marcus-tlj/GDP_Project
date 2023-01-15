using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DestroyItems : MonoBehaviour
{
    public int maxtrash = 0;
    public int currenttrsh;
    spawn m_spawn;
    public burntrash trashbarcount;
    float score =0;
    private void Start()
    {
        trashbarcount.setmaxhealth(20);
        GameObject spawner = GameObject.FindGameObjectWithTag("spawn");
        m_spawn = spawner.GetComponent<spawn>();
        score = Global_Variables.TotalPoints;
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
    private void Update()
    {
        if(currenttrsh >= 20)
        {
            SceneManager.LoadScene(1);

            if (Global_Variables.TotalPoints > PlayerPrefs.GetFloat("HighScore"))
            {
                PlayerPrefs.SetFloat("HighScore", Global_Variables.TotalPoints);
            }
            
        }
    }
}
