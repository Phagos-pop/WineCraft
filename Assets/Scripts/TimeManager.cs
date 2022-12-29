using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager
{
    public DateTime dateTime;
    public void Init()
    {
        dateTime = new DateTime(2000, 6, 1);
    }

    public void AddWeek()
    { 
        dateTime = dateTime.AddDays(7d);
    }

}
