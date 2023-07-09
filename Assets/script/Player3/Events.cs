using UnityEngine.SceneManagement;
using UnityEngine;

public class Events : MonoBehaviour
{
    public void ReplayGame()
    {
        SceneManager.LoadScene("Game 3");
    }
    
    public void QuitGame()
    {
        Application.Quit();
    }
}
