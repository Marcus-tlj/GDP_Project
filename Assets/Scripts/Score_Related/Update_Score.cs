using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Update_Score : MonoBehaviour
{
    public TextMeshProUGUI Score_text;
    void Update()
    {
        Score_text.text = Global_Variables.TotalPoints.ToString();
    }
}
