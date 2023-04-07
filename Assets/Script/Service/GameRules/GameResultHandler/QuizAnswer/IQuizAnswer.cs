using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IQuizAnswer 
{
     public void TryValidAnswer(int idButton);
     public int NumberCorrectAnswers { get; }
}
