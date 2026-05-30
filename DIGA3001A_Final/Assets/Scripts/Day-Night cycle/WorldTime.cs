using System;
using System.Collections;
using UnityEngine;

public class WorldTime : MonoBehaviour
{
    public event EventHandler<TimeSpan> WorldTimeChanged;
    public PlayerUV playerUV;
   public float dayLength;
   private TimeSpan currentTime;
   private float minuteLength => dayLength / WorldTimeConstants.MinutesInDay;

    TimeSpan startTime = new TimeSpan(17, 0, 0);
    TimeSpan endTime = new TimeSpan(6, 0, 0);

    private void Start()
    {
        currentTime = new TimeSpan(6, 0 , 0);
        StartCoroutine(AddMinute());
    }

    private void Update()
    {
        bool isNight = currentTime >= startTime || currentTime <= endTime;
       if (isNight)
        {
            playerUV.isFilling = true;
        }
        else
        {
            playerUV.isFilling = false;
        }
    }
    private IEnumerator AddMinute()
    {
        while (true)
        {
            if (!PauseController.isGamePaused)
        {
            currentTime += TimeSpan.FromMinutes(1);

            WorldTimeChanged?.Invoke(this, currentTime);
        }
            yield return new WaitForSeconds(minuteLength);
        }
        
        
    }
}
