using UnityEngine.SceneManagement;
using UnityEngine;

public class Events : MonoBehaviour
{
    public void ReplayGame()
    {
        SceneManager.LoadScene("game3");
    }
    
    public void QuitGame()
    {
        Application.Quit();
    }
}
