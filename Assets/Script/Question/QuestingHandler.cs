using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
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
        [SerializeField] private SaveLoadManager _saveLoadManager;

        public QuestionLvl Questing { get => _questing; private set => _questing = value; }


        private IImageBackgroundQuestion _imageBackground;
        private void Awake()
        {            
            _questing = Resources.Load<QuestionLvl>($"Lvl_{_saveLoadManager.GameData.indexButton}");
            GameRules = GetComponent<IGameRules>();
            _imageBackground = GetComponentInChildren<IImageBackgroundQuestion>();
             _buttons = _answersHolder.GetComponentsInChildren<QuestionButtonMV>().ToList();
        }
        private void Start()
        {
            _desctiptionQuestion.text = Questing.QuestionList[0].Desctiption; //[0].Desctiption;

            FirstInit(0);
        }
       
        private void FirstInit(int index)
        {           
          //  var answer = Questing.QuestionList[index].Answers;
            for (int i = 0; i < _buttons.Count; i++)
            {
                _buttons[i].InitButton(i, Questing.QuestionList[index].Answers[i]);
            }
            _imageBackground.OnSwitchSprite(Questing.QuestionList[index].Sprite);

        }

        public void NextQuesting(int id)
        {
            if(id >= Questing.QuestionList.Count)
            return;
            _desctiptionQuestion.text = Questing.QuestionList[id].Desctiption;
         
            for (int i = 0; i < _buttons.Count; i++)
            {
                _buttons[i].UpdateButton(i, Questing.QuestionList[id].Answers[i]);
            }
            _imageBackground.OnSwitchSprite(Questing.QuestionList[id].Sprite);
        }

        public int NumberQuestions() => Questing.QuestionList.Count ;

        public int CurrentCorrectAnswer(int NumberOfResponses)
        {
            return _questing.QuestionList[NumberOfResponses].CorrectAnswerId;
           
        }
    }



    public interface IQuesting
    {
        public void NextQuesting(int id);
        public int NumberQuestions();
        public int CurrentCorrectAnswer(int NumberOfResponses);
    }
}