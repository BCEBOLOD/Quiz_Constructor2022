using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Questions;
using UnityEngine.Events;
public class GameRules : MonoBehaviour//,IGameRules
{


   
    private QuestingHandler _questingHandler;
    private IQuesting _iQuesting;
    private IShuffle _iShuffleService; 
    private void Awake()
    {
     
        _iQuesting = gameObject.GetComponent<IQuesting>();
        _questingHandler = GetComponent<QuestingHandler>();    
        _iShuffleService = gameObject.GetComponentInChildren<IShuffle>();
    }
    private void Start()
    { 
       _iShuffleService.OnShuffleQuestion();

    }
}
