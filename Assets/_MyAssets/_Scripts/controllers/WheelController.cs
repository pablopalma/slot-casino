using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class WheelController : MonoBehaviour
{
    // stores the current handler for each wheel
    [SerializeField]
    private Scrollbar rowHandler;

    // gets the init wheel pos
    private float startWheelPos;

    // timer of duration spin
    private float timeInterval;   
    
    //gets the current value of scroll handler
    private float currentValue;

    // flag to checks if scroll handler it's complete and restart
    private bool isScrollCompleted;

    // list to add random positions to stop the wheel
    List<float> randomParts = new List<float>();

    private void Start()
    {
        rowHandler.onValueChanged.AddListener(scrollbarCallback);
        rowHandler.value = 1f;
        startWheelPos = rowHandler.value;
    }

    /// <summary>
    /// event that occurs when scrolling
    /// </summary>
    /// <param name="value"></param>
    private void scrollbarCallback(float value)
    {
        currentValue = value;
        if (startWheelPos > value)
        {
            isScrollCompleted = false;
        }
        else
        {
            isScrollCompleted = true;
        }

        startWheelPos = value;
    }
   
     /// <summary>
     /// rotates each wheel
     /// </summary>
     /// <param name="timer"></param>
     /// <returns></returns>
    public IEnumerator RotateWheel(float timer)
    {
        timeInterval = timer;
        randomParts.Add(1f);
        randomParts.Add(0.554f);
        randomParts.Add(0.257f);

        while (timeInterval >= 0)
        {
            timeInterval -= Time.deltaTime;
            rowHandler.value += 3 * Time.deltaTime;
            if (rowHandler.value >= 1)
                rowHandler.value = 0;

            yield return null;
        }
        int random = Random.Range(0, randomParts.Count);
        rowHandler.value = randomParts[random];
    }
}