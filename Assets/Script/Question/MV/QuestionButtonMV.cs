using TMPro;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Questions
{
    public class QuestionButtonMV : MonoBehaviour
    {
        [SerializeField] private int _id;
        [SerializeField] private Button _button;
        [SerializeField] private TextMeshProUGUI _answer;
        [SerializeField] private QuestingHandler _handler;

       
        private void Awake()
        {
            _answer = GetComponentInChildren<TextMeshProUGUI>();
            _button = GetComponentInChildren<Button>();     
        }
        private void Start() {
            
            _handler = GetComponentInParent<QuestingHandler>();      
        }
        public void InitButton(int id, string value)
        {
            _id = id;
            _answer.text = value;            
            _button.onClick.AddListener(() =>{ _handler.GameRules.TryValidAnswer(_id);});          
        }
         public void UpdateButton(int id, string value)
        {
            _id = id;
            _answer.text = value;   
        }

        public int GetIdButton()
         => _id;


    }

  
}