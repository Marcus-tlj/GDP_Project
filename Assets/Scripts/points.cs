using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class points : MonoBehaviour
{
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

    public static void IncrementBinCleanCount(int bin_id)
    {
        BinCleanCount[bin_id] ++;
        Streak += 1;
    }

    public static void ResetBinCleanCount(int bin_id)
    {
        BinCleanCount[bin_id] = 0;
    }

    public static void IncrementStreak()
    {
        Streak += 1;
    }

    public static void ResetStreak()
    {
        Streak = 0; 
    }

    public static void ChangePoints(int Change)
    {
        if (Streak >= MinimumStreak)
        {
            StreakMultiplier = Streak / MinimumStreak;
            TotalPoints += (int)(Change * StreakMultiplier * PointsMultiplier);
        }
        else
        {
            TotalPoints += (int)(Change * PointsMultiplier);
        }
    }

    public static void Contaminated(int bin_id)
    {
        ChangePoints(PtsLostForIncorrectDisposal);
        ChangePoints(BinCleanCount[bin_id] * PtsLostForContamination);
        ResetStreak();
        ResetBinCleanCount(bin_id);
    }


}
