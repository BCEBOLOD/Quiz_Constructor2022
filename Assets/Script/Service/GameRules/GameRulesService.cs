using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Questions;
using UnityEngine.Events;
public class GameRules : MonoBehaviour//,IGameRules
{


  //  [SerializeField] private GameplayUI _gameplayUI;
    private QuestingHandler _questingHandler;
    private Questions.IQuesting _iQuesting;
    private IShuffle _iShuffleService; 
    private void Awake()
    {
     
        _iQuesting = gameObject.GetComponent<Questions.IQuesting>();
        _questingHandler = GetComponent<QuestingHandler>();    
        _iShuffleService = gameObject.GetComponentInChildren<IShuffle>();
    }
    private void Start()
    { 
        _iShuffleService.OnShuffleQuestion();

    }
}
