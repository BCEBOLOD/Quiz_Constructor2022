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
        print(type);
      //  await ShowDisplayResult();
        switch (type)
        {
            case GameOverType.TimeOut:
             await    GameOverTypeTimeOut();
                break;
            case GameOverType.ZeroAttempts:
                await GameOverTypeZeroAttempts(type,_serviceQuizAnswer.NumberCorrectAnswers);
                break;
            case GameOverType.Victory:
                await GameOverTypeVictory();
                break;

            default:
                throw new System.Exception("GameOverService : необработанное исключение по перечислению GameOverType");

        }
    }

    private async Task GameOverTypeTimeOut()
    {

    }
    private async Task GameOverTypeZeroAttempts(GameOverType type,int countCorrectAnswers)
    {
        Debug.Log("Allax");
        _serviceGameOutcomeDisplay.CalculateInfo(type,countCorrectAnswers);
    }
    private async Task GameOverTypeVictory()
    {

    }
    private async Task ShowDisplayResult()
    {

    }
}
