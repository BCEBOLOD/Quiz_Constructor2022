using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveToScene : MonoBehaviour
{
    public void MoveToMainMenu(){
        SceneManager.LoadScene(0);
    }
}
