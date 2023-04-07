using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ShuffleButtons : MonoBehaviour,IShuffleButtons
{
    private Button[] _buttons; // массив кнопок, которые нужно перемешать

    private void Start()
    {
        _buttons = GetComponentsInChildren<Button>();
        OnShuffleButtons();
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


}
