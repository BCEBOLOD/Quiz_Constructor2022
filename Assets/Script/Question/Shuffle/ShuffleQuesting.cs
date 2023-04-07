using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Questions
{
    public class ShuffleQuesting : MonoBehaviour, IShuffleQuestion
    {
       
      
        public void OnShuffleQuestion(List<Question> question)
        {
            for (int i = 0; i < question.Count; i++)
            {
                int rndIndex = Random.Range(i, question.Count);
                var temp = question[rndIndex];
                question[rndIndex] = question[i];
                question[i] = temp;
            }
        }

        
    }



}