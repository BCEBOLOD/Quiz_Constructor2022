using System.Collections;
using System.Collections.Generic;
using Questions;
using UnityEngine;
using UnityEngine.UI;

public class ShuffleService : MonoBehaviour, IShuffle
{
     [SerializeField]  private Button[] _buttons;   
     private QuestingHandler _questingHandler;
      private void Awake() {
        _questingHandler = GetComponentInParent<QuestingHandler>();
      }
    public void OnShuffleButtons()
    {
         for (int i = 0; i < _buttons.Length; i++)
        {
            int rndIndex = Random.Range(i, _buttons.Length);
            Button temp = _buttons[rndIndex];
            _buttons[rndIndex] = _buttons[i];
            _buttons[i] = temp;
            _buttons[i].transform.SetSiblingIndex(i); // установка нового индекса для кнопки
        }
    }

    public void OnShuffleQuestion()
    {
         for (int i = 0; i < _questingHandler.Questing.QuestionList.Count; i++)
            {
                int rndIndex = Random.Range(i,_questingHandler.Questing.QuestionList.Count);
                var temp = _questingHandler.Questing.QuestionList[rndIndex];
                _questingHandler.Questing.QuestionList[rndIndex] = _questingHandler.Questing.QuestionList[i];
                _questingHandler.Questing.QuestionList[i] = temp;
            }
    }
}
