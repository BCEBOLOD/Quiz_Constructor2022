using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizAnswerService : MonoBehaviour,IQuizAnswer,IRestart
{
    [SerializeField] private int _maxCountQuesting;
    [SerializeField] private int _correctAnswer;
    [SerializeField] private int _numberCorrectAnswers;
    [SerializeField] private GameObject _quizPanel;//Панель с попытками,время,вопросы,ответы
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
        if (idButton == _correctAnswer)
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
        if (_correctAnswer == _maxCountQuesting)
        {        
            _serviceGameOver.GameOver(GameOverType.Victory);
          
            return;
            //Завершение и выход в гл меню
        }
        _correctAnswer++;
        _iShuffleService.OnShuffleButtons();
        _iQuesting.NextQuesting(_correctAnswer);
    }

    public void OnRestart()
    {
        _quizPanel.gameObject.SetActive(true);
        _correctAnswer = 0;
        _numberCorrectAnswers =0;
    }
}
