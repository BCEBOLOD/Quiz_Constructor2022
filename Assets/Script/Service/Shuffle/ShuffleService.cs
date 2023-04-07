using System.Collections;
using System.Collections.Generic;
using Questions;
using UnityEngine;
using UnityEngine.UI;

public class ShuffleService : MonoBehaviour, IShuffle
{
     [SerializeField]  private Button[] _buttons;   
      [SerializeField] private QuestingHandler _questingHandler;
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
         for (int i = 0; i < _questingHandler.Questing.Count; i++)
            {
                int rndIndex = Random.Range(i,_questingHandler.Questing.Count);
                var temp = _questingHandler.Questing[rndIndex];
                _questingHandler.Questing[rndIndex] = _questingHandler.Questing[i];
                _questingHandler.Questing[i] = temp;
            }
    }
}
