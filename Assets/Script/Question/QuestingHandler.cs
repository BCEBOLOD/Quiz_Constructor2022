using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;
using UnityEngine.UI;
using System.Threading.Tasks;
namespace Questions
{


    public class QuestingHandler : MonoBehaviour, IQuesting
    {
        [SerializeField] private List<Question> _questing;
        [SerializeField] private TextMeshProUGUI _desctiptionQuestion;
        [SerializeField] private List<QuestionButtonMV> _buttons;

        public IGameRules GameRules;
        [SerializeField] private GameObject _answersHolder;
        [SerializeField] private Image _backgroundSprite;

        public List<Question> Questing { get => _questing; private set => _questing = value; }

        private void Awake()
        {
            GameRules = GetComponent<IGameRules>();
        }
        private void Start()
        {
            _desctiptionQuestion.text = Questing[0].Desctiption;

            FirstInit(0);            
        }
        private void FirstInit(int index)
        {
            if (_answersHolder == null)
                return;
            _buttons = _answersHolder.GetComponentsInChildren<QuestionButtonMV>().ToList();
            var answer = Questing[index].Answers;
            for (int i = 0; i < _buttons.Count; i++)
            {
                _buttons[i].InitButton(i, answer[i]);
            }
              _backgroundSprite.sprite = Questing[index].Sprite;
        }

        public void NextQuesting(int id)
        {
            _desctiptionQuestion.text = Questing[id].Desctiption;
            var answer = Questing[id].Answers;
            for (int i = 0; i < _buttons.Count; i++)
            {
                _buttons[i].UpdateButton(i, answer[i]);
            }
            _backgroundSprite.sprite = Questing[id].Sprite;
         
        }

        public int NumberQuestions() => Questing.Count - 1;


    }



    public interface IQuesting
    {
        public void NextQuesting(int id);
        public int NumberQuestions();
    }
}