using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizAnswerService : MonoBehaviour,IQuizAnswer
{
    [SerializeField] private int _maxCountQuesting;
    [SerializeField] private int _correctAnswerId;
    [SerializeField] private int _numberCorrectAnswers;
    private IGameOver _serviceGameOver;
    private Questions.IQuesting _iQuesting;
    private IShuffle _iShuffleService;
    private IAttempts _attemptsService;

    public int NumberCorrectAnswers => _numberCorrectAnswers;

    private void Start()
    {
        _maxCountQuesting = _iQuesting.NumberQuestions(); // для ограничение на количество кликов
    }
    private void Awake()
    {
        _attemptsService = GetComponent<IAttempts>();
        _iShuffleService = GetComponentInChildren<IShuffle>();
        _serviceGameOver = GetComponent<IGameOver>();
        _iQuesting = GetComponent<Questions.IQuesting>();
    }

    public void TryValidAnswer(int idButton)
    {
        if (idButton == _correctAnswerId)
        {
            //     + количество отвеченных вопросов
            _numberCorrectAnswers++;
            // _gameplayUI.ResultClick(true);
        }
        else
        {
            _attemptsService.AdjustAttempts(-1,true);
            //_gameplayUI.ResultClick(false);
        }
        if (_correctAnswerId == _maxCountQuesting)
        {
            //   e_gameover?.Invoke();
            _serviceGameOver.GameOver(GameOverType.Victory);
            return;
            //Завершение и выход в гл меню
        }
        _correctAnswerId++;
        _iShuffleService.OnShuffleButtons();
        _iQuesting.NextQuesting(_correctAnswerId);
    }

}
