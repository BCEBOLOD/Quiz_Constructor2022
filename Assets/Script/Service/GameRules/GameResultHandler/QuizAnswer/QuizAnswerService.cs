using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizAnswerService : MonoBehaviour, IQuizAnswer, IRestart
{
    [SerializeField] private int _maxCountQuesting;
    [SerializeField] private int _correctAnswer;
    [SerializeField] private int _numberCorrectAnswers; // Количество верных ответов 
    [SerializeField] private int _numberOfResponses;
    [SerializeField] private GameObject _quizPanel;//Панель с попытками,время,вопросы,ответы
    [SerializeField] AnimationAnswersService _animationAnswers;
    private IGameOver _serviceGameOver;
    private Questions.IQuesting _iQuesting;
    private IShuffle _iShuffleService;
    private IAttempts _attemptsService;
    private AnimationAnswersService _animationAnswersService;
    public int NumberCorrectAnswers => _numberCorrectAnswers;

    private void Start()
    {
        _maxCountQuesting = _iQuesting.NumberQuestions(); // для ограничение на количество кликов
        _animationAnswersService.e_NextQuesting += () =>
        {
            _iShuffleService.OnShuffleButtons();
            _iQuesting.NextQuesting(_numberOfResponses);

        };

    }
    private void Awake()
    {
        _attemptsService = GetComponent<IAttempts>();
        _iShuffleService = GetComponentInChildren<IShuffle>();
        _serviceGameOver = GetComponent<IGameOver>();
        _iQuesting = GetComponent<Questions.IQuesting>();
        _animationAnswersService = GetComponentInChildren<AnimationAnswersService>();
    }

    public void TryValidAnswer(int idButton)
    {

        if (_numberCorrectAnswers == _maxCountQuesting)
        {
            _serviceGameOver.GameOver(GameOverType.Victory);
            return;
            //Завершение и выход в гл меню
        }
        if (_maxCountQuesting == _numberOfResponses)
        {
            return;
        }
        _correctAnswer = _iQuesting.CurrentCorrectAnswer(_numberOfResponses);

        if (idButton == _correctAnswer)
        {

            _numberCorrectAnswers++;

        }
        else
        {
            _attemptsService.AdjustAttempts(-1, true);

        }
        _numberOfResponses++;
        _animationAnswers.OnStartDescreseAnimation(_correctAnswer);


    }

    public void OnRestart()
    {
        _quizPanel.gameObject.SetActive(true);
        _correctAnswer = 0;
        _numberCorrectAnswers = 0;
        _numberOfResponses = 0;
    }
}
