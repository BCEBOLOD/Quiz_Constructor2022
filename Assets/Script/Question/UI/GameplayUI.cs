using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameplayUI : MonoBehaviour
{
    //  private ITimer _timer;
 //   private IAttempts _attempts;
    private IScore _score;
    [SerializeField] private GameOutcomeDisplayService _gameOutcomeDisplay;
    private void Awake()
    {
        _score = GetComponent<IScore>();
    //    _attempts = GetComponent<IAttempts>();
      
    }

    public void ResultClick(bool IsAnswerTrue)
    {
        if (IsAnswerTrue)
        {
            _score.AdjustScore(100);
        }
        else
        {
            _score.AdjustScore(-100);
       //     _attempts.AdjustAttempts(-1, true);
        }
    }
    // public void GameOver(GameOverType typeGameOver,int numberCorrectAnswers)
    // {
    //     _gameOutcomeDisplay.CalculateInfo(typeGameOver,numberCorrectAnswers);
    //     switch (typeGameOver)
    //     {
    //         case GameOverType.TimeOut:

    //         case GameOverType.ZeroAttempts:


    //             break;
    //         case GameOverType.Victory:

    //             break;

    //         default:

    //             break;
    //     }
    // }

}
