using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;
using UnityEngine.UI;

namespace Questions
{


    public class QuestingHandler : MonoBehaviour, IQuesting
    {
        [SerializeField] private QuestionLvl _questing;
        [SerializeField] private TextMeshProUGUI _desctiptionQuestion;
        [SerializeField] private List<QuestionButtonMV> _buttons;

        public IGameRules GameRules;
        [SerializeField] private GameObject _answersHolder;
        [SerializeField] private Image _backgroundSprite;

        public QuestionLvl Questing { get => _questing; private set => _questing = value; }


        private IImageBackgroundQuestion _imageBackground;
        private void Awake()
        {
            GameRules = GetComponent<IGameRules>();
            _imageBackground = GetComponentInChildren<IImageBackgroundQuestion>();
        }
        private void Start()
        {
            _desctiptionQuestion.text = Questing.QuestionList[0].Desctiption; //[0].Desctiption;

            FirstInit(0);
        }
        private void FirstInit(int index)
        {
            if (_answersHolder == null)
                return;
            _buttons = _answersHolder.GetComponentsInChildren<QuestionButtonMV>().ToList();
            var answer = Questing.QuestionList[index].Answers;
            for (int i = 0; i < _buttons.Count; i++)
            {
                _buttons[i].InitButton(i, answer[i]);
            }
            _imageBackground.OnSwitchSprite(Questing.QuestionList[index].Sprite);
         
        }

        public void NextQuesting(int id)
        {
            _desctiptionQuestion.text = Questing.QuestionList[id].Desctiption;
            var answer = Questing.QuestionList[id].Answers;
            for (int i = 0; i < _buttons.Count; i++)
            {
                _buttons[i].UpdateButton(i, answer[i]);
            }
             _imageBackground.OnSwitchSprite(Questing.QuestionList[id].Sprite);
        }

        public int NumberQuestions() => Questing.QuestionList.Count - 1;


    }



    public interface IQuesting
    {
        public void NextQuesting(int id);
        public int NumberQuestions();
    }
}