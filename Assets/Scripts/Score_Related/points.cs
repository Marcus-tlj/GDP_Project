using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class points : MonoBehaviour
{
    public static void IncrementBinCleanCount(int bin_id)
    {
        Global_Variables.BinCleanCount[bin_id] ++;
        Global_Variables.Streak += 1;
    }

    public static void ResetBinCleanCount(int bin_id)
    {
        Global_Variables.BinCleanCount[bin_id] = 0;
    }

    public static void IncrementStreak()
    {
        Global_Variables.Streak += 1;
    }

    public static void ResetStreak()
    {
        Global_Variables.Streak = 0; 
    }

    public static void ChangePoints(int Change)
    {
        if (Global_Variables.Streak >= Global_Variables.MinimumStreak)
        {
            Global_Variables.StreakMultiplier = Global_Variables.Streak / Global_Variables.MinimumStreak;
            Global_Variables.TotalPoints += (int)(Change * Global_Variables.StreakMultiplier * Global_Variables.PointsMultiplier);
        }
        else
        {
            Global_Variables.TotalPoints += (int)(Change * Global_Variables.PointsMultiplier);
        }
    }

    public static void Contaminated(int bin_id)
    {
        ChangePoints(Global_Variables.PtsLostForIncorrectDisposal);
        ChangePoints(Global_Variables.BinCleanCount[bin_id] * Global_Variables.PtsLostForContamination);
        ResetStreak();
        ResetBinCleanCount(bin_id);
    }


}
