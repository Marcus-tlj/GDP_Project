using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Retry : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void retrygame()
    {
        SceneManager.LoadScene(0);
        Global_Variables.TotalPoints = 0;
        points.ResetStreak();
    }
    public void leave()
    {
        Application.Quit();
    }
}
