using TMPro;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


    public class QuestionButtonMV : MonoBehaviour
    {
        [SerializeField] private int _id;
        [SerializeField] private GameObject _refForIQuizAnswer;//Ссылка на объект,который содержит реализацию IQuizAnswer
        [SerializeField] private Animator _animator;
        private Button _button;
        private TextMeshProUGUI _answer;
        private IQuizAnswer _serviceQuizAnswerService;
        private ITimer _timer;

        public Button Button { get => _button; set => _button = value; }
        public int Id { get => _id;  private set => _id = value; }
        public Animator Animator { get => _animator; set => _animator = value; }

        private void Awake()
        {
            _animator = GetComponent<Animator>();
            _serviceQuizAnswerService = _refForIQuizAnswer.GetComponent<IQuizAnswer>();
            _answer = GetComponentInChildren<TextMeshProUGUI>();
            Button = GetComponentInChildren<Button>();
            _timer = _refForIQuizAnswer.GetComponentInChildren<ITimer>();
        }
        public void InitButton(int id, string value)
        {
            Id = id;
            _answer.text = value;
            //Button.onClick.AddListener(() =>
            //{
            //    _serviceQuizAnswerService.TryValidAnswer(Id);
            //    if (_timer is SlideTimerService)
            //    {
            //        _timer.RestartTime();
            //    }
            //});
        }
        public void OnClickValid()
        {
            _serviceQuizAnswerService.TryValidAnswer(Id);
            if (_timer is SlideTimerService)
            {
              //  _timer.RestartTime();
            }
        }
        public void UpdateButton(int id, string value)
        {
            Id = id;
            _answer.text = value ;
        }

        public int GetIdButton()
         => Id;


    }


