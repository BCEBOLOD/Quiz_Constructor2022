using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;
using System.Threading.Tasks;

public class Timer : MonoBehaviour, ITimer //IGameOver
{
    [SerializeField] private float _timerGameplay;
    [SerializeField] private TextMeshProUGUI _timerText;
    [SerializeField] private float _baseTime;
    [SerializeField] private bool _startTimer = true;
    public float TimerGameplay
    {
        get => _timerGameplay;
        set => _timerGameplay = value;
    }

    private void Start()
    {
        OnRestart();
    }
    private IGameOver _serviceGameOver;
    private void Awake()
    {
        _serviceGameOver = GetComponent<IGameOver>();
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
        _timerGameplay = _baseTime;
       SelfActiveTimer(true);
    }
}
