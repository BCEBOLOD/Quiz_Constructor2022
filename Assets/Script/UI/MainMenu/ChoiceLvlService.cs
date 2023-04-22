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
        //  _buttonsList[0].onClick.AddListener(() => SceneManager.LoadSceneAsync($"gameplay_" + 0));

    }

    private void InitButtons()
    {

        // for (int i = 1; i < _buttonsList.Count; i++)
        // {
        //     int j = i;
        //     _buttonsList[i].onClick.AddListener(() => print(j));
        //     _buttonsList[i].interactable = _saveLoadManager.GameData.levels[i].IsOpen;
        //     _buttonsList[i].onClick.AddListener(() => SceneManager.LoadSceneAsync($"gameplay_" + j));
        // }
        for (int i = 0; i < _buttonsList.Count; i++)
        {
         //   _buttonsList[i].onClick.AddListener(() => print(i));
            _buttonsList[i].interactable = _saveLoadManager.GameData.levels[i].IsOpen;
       //      _buttonsList[i].onClick.AddListener(() => SceneManager.LoadSceneAsync($"gameplay_" + i));

        }
    }
    public void InitLvlIndexButton(int index){
        
        SceneManager.LoadSceneAsync($"gameplay_"+index);
    }
}
