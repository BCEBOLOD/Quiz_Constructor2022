using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public interface ITimer : IRestart
{
    public void SelfActiveTimer(bool active);
    public void RestartTime();
    public float TimerGameplay { get; }
    public TextMeshProUGUI TimerText { get; }
    public float BaseTime { get; }
    public bool StartTimer { get; }
}
