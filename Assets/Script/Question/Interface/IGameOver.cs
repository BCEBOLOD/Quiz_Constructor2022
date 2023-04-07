using UnityEngine.Events;
public interface IGameOver
{
 public event UnityAction<GameOverType> e_GameOver;
}
