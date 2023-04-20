using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
public class GameOutcomeDisplayView : MonoBehaviour,IRestart
{
   
    
    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _nextButton;

    [SerializeField] private TextMeshProUGUI _currentNumberLvl; 
    [SerializeField] private TextMeshProUGUI _numberCorrectAnswers;

    private IGameOutcomeDisplay _serviceIGameOutcomeDisplay;
    private void Awake()
    {
        _serviceIGameOutcomeDisplay = GetComponentInParent<IGameOutcomeDisplay>();
    }
    private void Start()
    {
      
    }

    public void ShowResult(int currentNumberLvl,  string numberCorrectAnswers)
    {
        _currentNumberLvl.text = currentNumberLvl.ToString();
    
        _numberCorrectAnswers.text = numberCorrectAnswers;
    }
    public void ShowButton(bool Restart, bool Next)
    {
        _restartButton.gameObject.SetActive(Restart);
        _nextButton.gameObject.SetActive(Next);
    }

    public void OnRestart()
    {
       ShowButton(false,false);
      gameObject.SetActive(false);
    }
}
