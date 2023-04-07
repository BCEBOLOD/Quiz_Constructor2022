using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;
using System.Threading.Tasks;

public class Timer : MonoBehaviour //IGameOver
{  
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


    private IGameOver _serviceGameOver;   
    private void Awake() {
       _serviceGameOver  = GetComponent<IGameOver>();
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
          _serviceGameOver.GameOver(GameOverType.TimeOut);     
            _startTimer = false;
        }
    }
    private void UpdateTimerText()
    =>
        _timerText.text = _timerGameplay.ToString();
    
   
}
