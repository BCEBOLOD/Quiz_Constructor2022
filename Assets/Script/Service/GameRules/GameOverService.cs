using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;

public class GameOverHandler : MonoBehaviour, IGameOver
{

    private ITimer _serviceTimer;
    private IAttempts _serviceAttempts;
    private IVictory _victoryService;
    private IQuizAnswer _serviceQuizAnswer;
    private IGameOutcomeDisplay _serviceGameOutcomeDisplay;
    private void Awake()
    {
        _serviceTimer = GetComponent<ITimer>();
        _serviceAttempts = GetComponent<IAttempts>();
        _victoryService = GetComponent<IVictory>();
        _serviceGameOutcomeDisplay = GetComponentInChildren<IGameOutcomeDisplay>();
        _serviceQuizAnswer = GetComponent<IQuizAnswer>();
    }
    public async Task GameOver(GameOverType type)
    {
        _serviceGameOutcomeDisplay.ActiveUiPanel(true);
        //
        _serviceTimer.SelfActiveTimer(false);
        //
        switch (type)
        {
            case GameOverType.TimeOut:
                await GameOverTypeTimeOut(type, _serviceQuizAnswer.NumberCorrectAnswers);
                break;
            case GameOverType.ZeroAttempts:
                await GameOverTypeZeroAttempts(type, _serviceQuizAnswer.NumberCorrectAnswers);
                break;
            case GameOverType.Victory:
                await GameOverTypeVictory(type, _serviceQuizAnswer.NumberCorrectAnswers);
                break;

            default:
                throw new System.Exception("GameOverService : необработанное исключение по перечислению GameOverType");
        }
          _serviceGameOutcomeDisplay.CalculateInfo(type, _serviceQuizAnswer.NumberCorrectAnswers);
    }

    private async Task GameOverTypeTimeOut(GameOverType type, int countCorrectAnswers)
    {
   //     _serviceGameOutcomeDisplay.CalculateInfo(type, countCorrectAnswers);
    }
    private async Task GameOverTypeZeroAttempts(GameOverType type, int countCorrectAnswers)
    {

     //   _serviceGameOutcomeDisplay.CalculateInfo(type, countCorrectAnswers);
    }
    private async Task GameOverTypeVictory(GameOverType type, int countCorrectAnswers)
    {
       // _serviceGameOutcomeDisplay.CalculateInfo(type, countCorrectAnswers);
    }

}
