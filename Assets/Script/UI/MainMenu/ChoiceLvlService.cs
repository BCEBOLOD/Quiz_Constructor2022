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
            _buttonsList[i].interactable = _saveLoadManager.GameData.levels[i].IsOpen;     
        }
    }
    public void InitLvlIndexButton(int index){               
      _saveLoadManager.SaveInitButton(index);
      SceneManager.LoadScene("gameplay");
    }
}
