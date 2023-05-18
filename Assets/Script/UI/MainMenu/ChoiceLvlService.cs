using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.SceneManagement;
public class ChoiceLvlService : MonoBehaviour
{
    private List<Button> _buttonsList = new(10);
    [SerializeField] private GameObject _buttonsHolder;//Ссылка на go, который содержит все кнопки
    [SerializeField] private SaveLoadManager _saveLoadManager;
    [SerializeField] Sprite[] _open_Close_Button;
    private void Awake()
    {
        _buttonsList = _buttonsHolder.GetComponentsInChildren<Button>().ToList();
    }
    private void Start()
    {
        InitButtons();    

    }

    private void InitButtons()
    {       
        for (int i = 0; i < _buttonsList.Count; i++)
        {
            if (_saveLoadManager.GameData.levels[i].IsOpen)
            {
            _buttonsList[i].interactable = true;
                _buttonsList[i].image.sprite = _open_Close_Button[0];
            }
            else
            {
                _buttonsList[i].interactable = false;
                _buttonsList[i].image.sprite = _open_Close_Button[1];
            }

        }
    }
    public void InitLvlIndexButton(int index){               
      _saveLoadManager.SaveInitButton(index);
      SceneManager.LoadScene("gameplay");
    }
}
