using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;
public class GameOutcomeDisplayService : MonoBehaviour,IGameOutcomeDisplay
{ 
    private int _totalQuestions;

    [SerializeField] private Questions.QuestingHandler _questions;

    private void Start()
    {
        // _restartButton.onClick.AddListener(() => RestartGame());
        // _nextButton.onClick.AddListener(() => NextLvl());

    //    gameObject.SetActive(false);
    }
    public void CalculateInfo(GameOverType type, int numberCorrectAnswers)
    {
        // _totalQuestions = _questions.Questing.Count;
        // gameObject.SetActive(true);
        // if (type == GameOverType.TimeOut || type == GameOverType.ZeroAttempts)
        // {
        //     //Без кнопок дальше
        //     _nextButton.gameObject.SetActive(false);
        // }
        // else
        // {
        //     //кнопка с переходом на следующий уровень
        // }
        // _numberCorrectAnswers.text = $"{numberCorrectAnswers}/{_totalQuestions}";
    }

    // public void NextLvl()
    // {

    // }
    // public void RestartGame()
    // {
    //     _nextButton.gameObject.SetActive(true);
    //     _scoreText.text = "";
    //     _numberCorrectAnswers.text = "";
    //     gameObject.SetActive(false);
    // }

    public void Victory()
    {
        throw new System.NotImplementedException();
    }

    public void TimeOut()
    {
        throw new System.NotImplementedException();
    }

    public void ZeroAttempts()
    {
        throw new System.NotImplementedException();
    }

    public void RestartGame()
    {
        throw new System.NotImplementedException();
    }

    public void NextLvl()
    {
        throw new System.NotImplementedException();
    }
}
