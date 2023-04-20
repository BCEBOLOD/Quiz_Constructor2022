using System.Collections.Generic;
using UnityEngine;
 [CreateAssetMenu(fileName = "New QuestionLvl", menuName = "Question/QuestionLvl")]
public class QuestionLvl : ScriptableObject
{
    [SerializeField] private string _descriptionLvl;// тема того, что за вопросы будут.Оно чисто для себя,чтобы по описанию узнать содержмое
    [SerializeField] private float _timer;//Время на прохождения уровня
    [SerializeField] private int _numberLvl;//нумерация уровня
    [SerializeField] private List<Questions.Question> _questionList; // коллекция вопросов
    public List<Questions.Question> QuestionList => _questionList;
    public int CountQuestion => _questionList.Count;// Количество вопросов всего

}
