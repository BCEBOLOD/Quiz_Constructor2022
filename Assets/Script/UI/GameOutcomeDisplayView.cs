using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameOutcomeDisplayView : MonoBehaviour
{
    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _nextButton;

    [SerializeField] private TextMeshProUGUI _currentNumberLvl;
    [SerializeField] private TextMeshProUGUI _scoreText;

    [SerializeField] private TextMeshProUGUI _numberCorrectAnswers;

    private IGameOutcomeDisplay _serviceIGameOutcomeDisplay;
    private void Awake() {
        _serviceIGameOutcomeDisplay = GetComponentInParent<IGameOutcomeDisplay>();
    }
     private void Start()
    {
     //   _restartButton.onClick.AddListener(() => _serviceIGameOutcomeDisplay.RestartGame());
      //  _nextButton.onClick.AddListener(() => _serviceIGameOutcomeDisplay.NextLvl());
  
    }
}
