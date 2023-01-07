using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TImer : MonoBehaviour
{
    private static float time;

    private float TenSecondTimer;
    private float SpeedChangeInterval = 30;
    private float SpeedChangeTimer;
    private float MultiplierIncreaseInterval = 60;
    private float MultiplierIncreaseTimer;
    private float BinEmptyTimer;

    void Update()
    {
        time += Time.deltaTime;
        TenSecondTimer = time;
        SpeedChangeInterval = time;
        BinEmptyTimer = time;
        if (TenSecondTimer > points.TimeInterval)
        {
            TenSecondTimer -= 10;
            points.ChangePoints(points.PtsPerTimeInterval);
        }
        if (SpeedChangeTimer > SpeedChangeInterval)
        {
            //Speed += .1
            // if Speed
            SpeedChangeTimer -= 10;
        }
        if (MultiplierIncreaseTimer > MultiplierIncreaseInterval)
        {
            points.PointsMultiplier += 0.1f;
        }
        if (BinEmptyTimer > points.BinEmptyInterval)
        {
            BinEmptyTimer -= 10;
            points.BinCleanCount[0] = 0;
            points.BinCleanCount[1] = 0;
            points.BinCleanCount[2] = 0;
            points.BinCleanCount[3] = 0;
        }
    }

    public float GetCurrentTimer()
    {
        return time;
    }
}
