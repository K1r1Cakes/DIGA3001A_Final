using System;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class WorldLight : MonoBehaviour
{
    public Light2D light;
    public WorldTime worldTime;
    public Gradient gradient;

    private void Awake()
    {
        worldTime.WorldTimeChanged += OnWorldTimeChanged;
    }

    private void OnDestroy()
    {
         worldTime.WorldTimeChanged -= OnWorldTimeChanged;
    }
    private void OnWorldTimeChanged(object sender, TimeSpan newTime)
    {
        light.color = gradient.Evaluate(PercentOfDay(newTime));
    }

    private float PercentOfDay(TimeSpan timeSpan)
    {
        return (float)timeSpan.TotalMinutes % WorldTimeConstants.MinutesInDay / WorldTimeConstants.MinutesInDay;
    }
}
