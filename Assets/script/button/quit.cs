using UnityEngine;
using UnityEngine.SceneManagement;

public class Quit : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        AutosaveManager autosaveManager = FindObjectOfType<AutosaveManager>();
        if (autosaveManager != null)
        {
            autosaveManager.Autosave();
        }
        
        Debug.Log("Anda telah keluar");
        Application.Quit();
    }
}
