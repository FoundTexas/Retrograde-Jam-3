using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    static int curScore;

    public static void ResetScore()
    {
        curScore = 0;
    }

    public static void ChangeScore(int value)
    {
        curScore += value;
    }

    public static int GetScore()
    {
        return curScore;
    }

}
