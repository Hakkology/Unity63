using UnityEngine;
using System;

public class PlayerTimerController : MonoBehaviour {
    public float timer = 0f;

    private void Update() {
        timer += Time.deltaTime;
        UpdateTimerText();
    }

    public void IncreaseTimer()
    {
        timer += 5f;
    }

    private void UpdateTimerText()
    {
        TimeSpan timeSpan = TimeSpan.FromSeconds(timer);
        string formattedTime = string.Format("{0:00}:{1:00}", (int)timeSpan.TotalMinutes, timeSpan.Seconds);
        HUDController.Instance.UpdateTimerText(formattedTime);
    }
}