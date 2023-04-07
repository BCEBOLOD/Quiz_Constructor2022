using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace Questions
{

    [CreateAssetMenu(fileName = "New Question", menuName = "Question/Question")]
    public class Question : ScriptableObject
    {
        [SerializeField] private string _description;
        public string Desctiption => _description;

        [SerializeField] private List<string> _answers;
        public List<string> Answers => _answers;


        [SerializeField] private int _correctAnswerId;
        public int CorrectAnswerId => _correctAnswerId;

        public Sprite? Sprite => _sprite;

        [SerializeField] private Sprite? _sprite;
    }
}