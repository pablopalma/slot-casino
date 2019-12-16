using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class RandomTimer
{
    static float randomVal;

    /// <summary>
    /// generates a random timer interval for spin
    /// </summary>
    /// <returns></returns>
    public static float RandomInterval()
    {
        randomVal = Random.Range(2, 4);
       
        return randomVal;
    }
}
