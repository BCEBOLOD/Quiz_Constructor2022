using TMPro;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Questions
{
    public class QuestionButtonMV : MonoBehaviour
    {
        [SerializeField] private int _id;
        [SerializeField] private GameObject  _refForIQuizAnswer;//Ссылка на объект,который содержит реализацию IQuizAnswer
        private Button _button;
        private TextMeshProUGUI _answer;
        private IQuizAnswer _serviceQuizAnswerService;


        private void Awake()
        {
            _serviceQuizAnswerService = _refForIQuizAnswer.GetComponent<IQuizAnswer>();
            _answer = GetComponentInChildren<TextMeshProUGUI>();
            _button = GetComponentInChildren<Button>();
        }
        public void InitButton(int id, string value)
        {
            _id = id;
            _answer.text = value;
            _button.onClick.AddListener(() => { _serviceQuizAnswerService.TryValidAnswer(_id); });
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