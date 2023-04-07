using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class Timer : MonoBehaviour, IGameOver
{
    public event UnityAction<GameOverType> e_GameOver;
    [SerializeField] private TextMeshProUGUI _timerText;
    [SerializeField] private float _timerGameplay;
    [SerializeField] private bool _startTimer = true;
    public float TimerGameplay
    {
        get => _timerGameplay;
        set
        {
            if (_timerGameplay != value)
            {
                _timerGameplay = value;
                UpdateTimerText();
            }
        }
    }


  
    private void Start()
    {
       // _timerGameplay = 30;
    }
    private void Update()
    {
        if (_startTimer)
            SubstractSecond();
    }

    private void SubstractSecond()
    {
        TimerGameplay -= 1 * Time.deltaTime;
        if (TimerGameplay <= 0)
        {
            e_GameOver?.Invoke(GameOverType.TimeOut);
            _startTimer = false;
        }
    }
    private void UpdateTimerText()
    {
        _timerText.text = _timerGameplay.ToString();
    }

}
