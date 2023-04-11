using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Restart : MonoBehaviour, IRestart
{
    [SerializeField] private Button _restartButton;
    [SerializeField] private IGameOutcomeDisplay _iGameOutcomeDisplay;
    [SerializeField] private ITimer _serviceTimer;
    [SerializeField] private IAttempts _serviceAttempts;
    [SerializeField] private GameOutcomeDisplayView _gameOutcomeDisplayView;
    [SerializeField] private IScore _serviceScore;
    [SerializeField] private QuizAnswerService _serviceuizAnswer; 
    /*
    Дисплей UI,
    Таймер,
    Очки,
    */
    private void Awake()
    {
        _iGameOutcomeDisplay = GetComponentInParent<IGameOutcomeDisplay>();
        _serviceTimer = GetComponentInParent<ITimer>();
        _serviceAttempts = GetComponentInParent<IAttempts>();
    }
    private void Start()
    {
        _restartButton.onClick.AddListener(() => OnRestart());
    }
    public void OnRestart()
    {
    //    _iGameOutcomeDisplay.RestartGame();
   
        _serviceTimer.OnRestart();
        _serviceAttempts.OnRestart();
        _gameOutcomeDisplayView.OnRestart();
        _serviceuizAnswer.OnRestart();
    }
}
