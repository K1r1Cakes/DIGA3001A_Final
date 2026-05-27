using UnityEngine;
using TMPro;
using System;

public class WorldTimeDisplay : MonoBehaviour
{
    public WorldTime worldTime;
    public TextMeshProUGUI timeText;

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
        timeText.text = newTime.ToString(@"hh\:mm");
    }
}
