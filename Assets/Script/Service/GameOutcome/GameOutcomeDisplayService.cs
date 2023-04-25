using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;
public class GameOutcomeDisplayService : MonoBehaviour,IGameOutcomeDisplay
{ 
    private int _totalQuestions;
   // [SerializeField] private Button _nextButton;
    private string _numberCorrectAnswers;
    [SerializeField] private Questions.QuestingHandler _questions;
    [SerializeField] private GameOutcomeDisplayView _view;
  
   
    public void CalculateInfo(GameOverType type, int numberCorrectAnswers)
    {
        _totalQuestions = _questions.Questing.QuestionList.Count;
        gameObject.SetActive(true);
        if (type == GameOverType.TimeOut || type == GameOverType.ZeroAttempts)
        {
            _view.ShowButton(true,false);
            //Без кнопок дальше
           // _nextButton.gameObject.SetActive(false);
        }
        else
        {
            _view.ShowButton(true,true);
            //кнопка с переходом на следующий уровень
        }
        _numberCorrectAnswers= $"{numberCorrectAnswers}/{_totalQuestions}";
        _view.ShowResult(0,_numberCorrectAnswers);
    }  

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

    public void ActiveUiPanel(bool activeself)
    {
       _view.gameObject.SetActive(activeself);
    }
}
