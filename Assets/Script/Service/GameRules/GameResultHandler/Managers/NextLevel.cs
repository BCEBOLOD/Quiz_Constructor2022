using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelManager : MonoBehaviour
{
    [SerializeField] private AnswersAnimationService _animationAnswersService;
    [SerializeField] private SaveLoadManager _saveloadManager;
    [SerializeField] QuestingHandler _questingHandler;
    [SerializeField] private Restart _restart;
    [SerializeField] private QuizAnswerService _quizAnswerService;
   
    public void MoveToNextLvl()
    {
        _saveloadManager.OpenNextLvl(true);
_animationAnswersService.TryStopCoroutine();
        _questingHandler.OnLoadQuestingLvl(_saveloadManager.GameData.indexButton);
        _restart.OnRestart();
        _quizAnswerService.OnUpdateNumberCorrectAnswers();
        //  _saveloadManager.OpenNextLvl(true);
        /*
        переключить ид кнопки лвла
         Смена сборника вопроса
         рестарт игры
        */

    }
}
