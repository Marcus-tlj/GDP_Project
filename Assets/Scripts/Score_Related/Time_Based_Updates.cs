using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Time_Based_Updates : MonoBehaviour
{
    private float time;   

    private void Start()
    {
        StartCoroutine(EmptyBin());
        StartCoroutine(IncreaseMultiplier());
        StartCoroutine(Timer());
        StartCoroutine(PointsForTime());
        StartCoroutine(IncreaseSpeed());
    }

    public float GetCurrentTimer()
    {
        return time;
    }
    IEnumerator Timer()
    {
        while (true)
        {
            time += Time.deltaTime;
            yield return null;
        }
    }
    IEnumerator PointsForTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(Global_Variables.TimeInterval);
            points.ChangePoints(Global_Variables.PtsPerTimeInterval);
        }
    }
    IEnumerator IncreaseSpeed()
    {
        while (true)
        {
            yield return new WaitForSeconds(Global_Variables.SpeedChangeInterval);
            Debug.Log("Change Speed");           
        }
    }
    IEnumerator IncreaseMultiplier()
    {
        while (true)
        {
            yield return new WaitForSeconds(Global_Variables.MultiplierIncreaseInterval);
            Global_Variables.PointsMultiplier += 0.1f;
        }
    }
    IEnumerator EmptyBin()
    {
        while (true)
        {
            yield return new WaitForSeconds(Global_Variables.BinEmptyInterval);
            Global_Variables.BinCleanCount = new int[4];
        }
    }
}
