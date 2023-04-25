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
            if(id >= Questing.QuestionList.Count)
            return;
            _desctiptionQuestion.text = Questing.QuestionList[id].Desctiption;
            var answer = Questing.QuestionList[id].Answers;
            for (int i = 0; i < _buttons.Count; i++)
            {
                _buttons[i].UpdateButton(i, answer[i]);
            }
            _imageBackground.OnSwitchSprite(Questing.QuestionList[id].Sprite);
        }

        public int NumberQuestions() => Questing.QuestionList.Count ;


    }



    public interface IQuesting
    {
        public void NextQuesting(int id);
        public int NumberQuestions();
    }
}