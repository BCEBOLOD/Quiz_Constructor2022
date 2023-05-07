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
    [SerializeField] AnswersAnimationService _animationAnswers;
    private IGameOver _serviceGameOver;
    private IQuesting _iQuesting;
    private IShuffle _iShuffleService;
    private IAttempts _attemptsService;
    private AnswersAnimationService _animationAnswersService;
    public int NumberCorrectAnswers => _numberCorrectAnswers;
     public int MaxCountQuesting =>_maxCountQuesting;

    private void Start()
    {
        _maxCountQuesting = _iQuesting.NumberQuestions(); // для ограничение на количество кликов
        _animationAnswersService.e_NextQuesting += () =>
        {
            //_numberOfResponses++;
            _iShuffleService.OnShuffleButtons();
            if(_numberOfResponses <= _maxCountQuesting)
            _iQuesting.NextQuesting(_numberOfResponses);
        };

    }
   
    private void Awake()
    {
        _attemptsService = GetComponent<IAttempts>();
        _iShuffleService = GetComponentInChildren<IShuffle>();
        _serviceGameOver = GetComponent<IGameOver>();
        _iQuesting = GetComponent<IQuesting>();
        _animationAnswersService = GetComponentInChildren<AnswersAnimationService>();
    }
    public void OnUpdateNumberCorrectAnswers()=>
          _maxCountQuesting = _iQuesting.NumberQuestions(); // для ограничение на количество кликов
        
    public void TryValidAnswer(int idButton)
    {
        if (_numberOfResponses != _maxCountQuesting)
        {
            _correctAnswer = _iQuesting.CurrentCorrectAnswer(_numberOfResponses);
            _animationAnswers.OnStartDescreseAnimation(_correctAnswer);
        }
        if (idButton == _correctAnswer && _numberOfResponses != _maxCountQuesting)
            _numberCorrectAnswers++;
        else
            _attemptsService.AdjustAttempts(-1, true);
//
        _numberOfResponses++;

            var percent = (_maxCountQuesting * _numberCorrectAnswers)/ 100;
        if (_numberOfResponses == _maxCountQuesting )
        {
            if (_numberCorrectAnswers == _maxCountQuesting || percent >= 70)
            {
                _serviceGameOver.GameOver(GameOverType.Victory);
                return;

            }       
           _serviceGameOver.GameOver(GameOverType.GameFinished);
        //   return;
            //Завершение и выход в гл меню
        }



        //if (_maxCountQuesting <= _numberOfResponses)
        //    return;


        //   _numberOfResponses++;
    }

    public void OnRestart()
    {
        _quizPanel.gameObject.SetActive(true);
        _correctAnswer = 0;
        _numberCorrectAnswers = 0;
        _numberOfResponses = 0;
           _iQuesting.NextQuesting(_numberOfResponses);
           _animationAnswers.TryStopCoroutine();
    }
}
