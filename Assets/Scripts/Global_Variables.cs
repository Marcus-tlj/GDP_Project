using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Global_Variables : MonoBehaviour
{
    //Points
    public static int TotalPoints = 0;

    public static int PtsPerTimeInterval = 100;
    public static float TimeInterval = 10;

    public static int PtsGainForCorrectPreperation = 50;
    public static int PtsLostForIncorrectPreperation = -25;

    public static int PtsGainForCorrectDisposal = 70;
    public static int PtsLostForIncorrectDisposal = -35;

    public static int PtsLostForContamination = 80;

    public static float PointsMultiplier = 1f;
    public static float StreakMultiplier = 1f;

    public static int Streak = 0;
    public static int MinimumStreak = 5;
    public static float BinEmptyInterval = 360;

    public static int[] BinCleanCount = new int[4];

    public static float MultiplierIncreaseInterval = 60;
    public static float SpeedChangeInterval = 30;
}
