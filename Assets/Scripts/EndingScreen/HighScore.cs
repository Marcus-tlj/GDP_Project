using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class HighScore : MonoBehaviour
{
    public TextMeshProUGUI score;
    public TextMeshProUGUI highscore;
    // Start is called before the first frame update
    void Start()
    {
        score.text = "Score: " + Global_Variables.TotalPoints;
        highscore.text = "HighScore: " + PlayerPrefs.GetFloat("HighScore");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
