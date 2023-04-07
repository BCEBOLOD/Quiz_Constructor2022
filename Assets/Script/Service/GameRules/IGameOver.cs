using UnityEngine.Events;
using System.Threading.Tasks;
public interface IGameOver
{
 public Task GameOver(GameOverType type); 
}
