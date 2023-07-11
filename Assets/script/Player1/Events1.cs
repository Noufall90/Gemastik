using UnityEngine.SceneManagement;
using UnityEngine;

public class Events1 : MonoBehaviour
{
    public void ReplayGame()
    {
        SceneManager.LoadScene("game1");
    }
    
    public void QuitGame()
    {
        Application.Quit();
    }
}
