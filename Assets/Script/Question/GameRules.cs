using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Questions;
using UnityEngine.Events;
public class GameRules : MonoBehaviour, IGameRules
{
    public event UnityAction e_gameover;
    [SerializeField] private int _maxCountQuesting;
    [SerializeField] private int _correctAnswerId;
   [SerializeField] private int _numberCorrectAnswers;

    [SerializeField] private GameplayUI _gameplayUI;
    private QuestingHandler _questingHandler;
    private IShuffleButtons _iShuffleButtons;
    private Questions.IQuesting _iQuesting;
    private IShuffleQuestion _iShuffleQuestion;


    ///Для них нужен родитель на котором висят чтобы получить интерфейс
    [SerializeField] private GameObject _timerAtteptsHolder;
    private Timer _timer;
     private IAttempts _attempts;


    private void Awake()
    {
        _iQuesting = gameObject.GetComponent<Questions.IQuesting>();
        _questingHandler = GetComponent<QuestingHandler>();
        _timer = _timerAtteptsHolder.GetComponent<Timer>();
        _attempts = _timerAtteptsHolder.GetComponent<IAttempts>();
    }
    private void Start()
    {
        _iShuffleQuestion = gameObject.GetComponent<IShuffleQuestion>();
        _iShuffleButtons = GetComponent<IShuffleButtons>();
        //
        _maxCountQuesting = _iQuesting.NumberQuestions(); // для ограничение на количество кликов
        _iShuffleQuestion.OnShuffleQuestion(_questingHandler.Questing);

        //Подписки 
        _timer.e_GameOver += GameOver;
    }

    public void TryValidAnswer(int idButton)
    {
        if (idButton == _correctAnswerId)
        {
            //     + количество отвеченных вопросов
            _numberCorrectAnswers++;
            _gameplayUI.ResultClick(true);
        }
        else
        {
            _gameplayUI.ResultClick(false);
        }
        if (_correctAnswerId == _maxCountQuesting)
        {
            e_gameover?.Invoke();
            return;
            //Завершение и выход в гл меню
        }
        _correctAnswerId++;
        _iShuffleButtons.OnShuffleButtons();
        _iQuesting.NextQuesting(_correctAnswerId);
    }

    private void GameOver(GameOverType typeGameOver)
    {

        switch (typeGameOver)
        {
            case GameOverType.TimeOut:
            case GameOverType.ZeroAttempts:
                //без  подсчета.Сколько ответил из скольки
                break;
            case GameOverType.Victory:
                //Подсчет очков,ответов верный и сколько вообще.
                break;

            default:

                break;
        }
        _gameplayUI.GameOver(typeGameOver,_numberCorrectAnswers);
    }


}
