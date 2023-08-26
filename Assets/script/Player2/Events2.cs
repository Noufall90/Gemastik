using UnityEngine.SceneManagement;
using UnityEngine;

public class Events2 : MonoBehaviour
{
    public void ReplayGame()
    {
        SceneManager.LoadScene("game2");
    }
    
    public void QuitGame()
    {
        Application.Quit();
    }
}
