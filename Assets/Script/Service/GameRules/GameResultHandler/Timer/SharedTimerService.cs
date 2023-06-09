using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;
using System.Threading.Tasks;

public class SharedTimerService : MonoBehaviour, ITimer //IGameOver
{
    [SerializeField] private float _timerGameplay;
    [SerializeField] private TextMeshProUGUI _timerText;
    [SerializeField] private float _baseTime;
    [SerializeField] private bool _startTimer = true;
    public TextMeshProUGUI TimerText => _timerText;

    public float BaseTime => _baseTime;

    public bool StartTimer => _startTimer;
    public float TimerGameplay
    {
        get => _timerGameplay;
        private set => _timerGameplay = value;
    }

    private void Start()
    {
        OnRestart();
    }
    private IGameOver _serviceGameOver;
    private void Awake()
    {
        _serviceGameOver = GetComponentInParent<IGameOver>();
    }
    private void Update()
    {
        if (_startTimer)
            SubstractSecond();
    }

    private void SubstractSecond()
    {
        TimerGameplay -= 1 * Time.deltaTime;
        _timerText.text = _timerGameplay.ToString();
        if (TimerGameplay <= 0)
        {
            _serviceGameOver.GameOver(GameOverType.TimeOut);
            _startTimer = false;
        }
    }

    public void SelfActiveTimer(bool active)
    {
        _startTimer = active;
        _timerText.gameObject.SetActive(active);

    }

    public void OnRestart()
    {
     RestartTime();
        SelfActiveTimer(true);
    }
    
    public void RestartTime()
    {
       _timerGameplay = _baseTime;
    }
}
