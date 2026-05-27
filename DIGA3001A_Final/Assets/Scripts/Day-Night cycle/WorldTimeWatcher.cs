using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Linq;

public class WorldTimeWatcher : MonoBehaviour
{
    public WorldTime worldTime;

    public List<Schedule> schedule;

    public class Schedule
    {
        public int Hour;
        public int Minute;
        public UnityEvent action;
    }

    private void Start()
    {
        worldTime.WorldTimeChanged += CheckSchedule;
    }

    private void OnDestroy()
    {
         worldTime.WorldTimeChanged -= CheckSchedule;
    }
    
    private void CheckSchedule(object sender, TimeSpan newTime)
    {
        var _schedule = schedule.FirstOrDefault(s =>
        s.Hour == newTime.Hours &&
        s.Minute == newTime.Minutes);

        _schedule?.action?.Invoke();
    }
}
