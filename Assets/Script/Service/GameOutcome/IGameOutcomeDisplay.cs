using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGameOutcomeDisplay
{
    public void Victory();
    public void TimeOut();
    public void ZeroAttempts();

    public void RestartGame();
    public void NextLvl();
    public void CalculateInfo(GameOverType type, int numberCorrectAnswers);
    public void ActiveUiPanel(bool activeself);
}
