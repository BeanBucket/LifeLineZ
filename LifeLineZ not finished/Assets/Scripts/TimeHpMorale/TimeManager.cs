using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    private static int time = 390;
    public Text timeBox;
    private int hours;
    private int minuts;

    public static void SetTime(int timeSet)
    {
        time = timeSet;
    }
    public void Update()
    {
        CalculateTime();
        timeBox.text = hours.ToString("00") + " : " +minuts.ToString("00");
    }
    private void CalculateTime()
    {
        hours = time / 60;
        minuts = time - hours * 60;
    }
    public static void AddTime(int howMuch)
    {
        time += howMuch;
    }
    public static int ReturnTime()
    {
        return time;
    }

}
