using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;
using System.Threading.Tasks;

public class SlideTimerService : MonoBehaviour, ITimer //IGameOver
{
    [SerializeField] private float _timerGameplay;
    [SerializeField] private TextMeshProUGUI _timerText;
    [SerializeField] private float _baseTime;
    [SerializeField] private bool _startTimer = true;
    [SerializeField] private AnimationAnswersService _animationAnswersService;
    public float TimerGameplay
    {
        get => _timerGameplay;
        private set => _timerGameplay = value;
    }

    public TextMeshProUGUI TimerText => _timerText;

    public float BaseTime => _baseTime;

    public bool StartTimer => _startTimer;

    private void Start()
    {
        _animationAnswersService.e_NextQuesting += () =>
        {
            OnRestart();
            
        };
        _animationAnswersService.e_AwaitNewQuesting += () =>
        {
            SelfActiveTimer(false);
        };
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
        _timerText.text = Mathf.RoundToInt(_timerGameplay).ToString();
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
        SelfActiveTimer(true);
        RestartTime();
    }

    public void RestartTime()
    {
        _timerGameplay = _baseTime;
    }
}
