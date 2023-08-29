using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Clock : MonoBehaviour
{

    public GameObject secondHand;
    public GameObject minuteHand;
    public GameObject hourHand;
    string oldSeconds;

    void Update()
    {
        string seconds = System.DateTime.UtcNow.ToString("ss");

        if (seconds != oldSeconds)
        {
            UpdateTimer();
        }
        oldSeconds = seconds;
    }

    void UpdateTimer()
    {
        int secondsInt = int.Parse(System.DateTime.UtcNow.ToString("ss"));
        int minutesInt = int.Parse(System.DateTime.UtcNow.ToString("mm"));
        int hoursInt = int.Parse(System.DateTime.UtcNow.ToLocalTime().ToString("hh"));
        //print(hoursInt + " : " + minutesInt + " : " + secondsInt);

        iTween.RotateTo(secondHand, iTween.Hash("z", secondsInt * 6 * -1, "time", 1, "easetype", "easeOutQuint"));
        iTween.RotateTo(minuteHand, iTween.Hash("z", minutesInt * 6 * -1, "time", 1, "easetype", "easeOutElastic"));
        float hourDistance = (float)(minutesInt) / 60f;
        iTween.RotateTo(hourHand, iTween.Hash("z", (hoursInt + hourDistance) * 360 / 12 * -1, "time", 1, "easetype", "easeOutQuint"));
    }
}
