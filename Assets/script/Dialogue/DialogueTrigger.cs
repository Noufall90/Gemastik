using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    
    [SerializeField] GameObject pauseMenu;
     
    public void TriggerDialogue()
    {
        // Debug.Log("TriggerDialogue");
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

    public void PauseMenu()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Lanjut()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Keluar(int SceneID)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneID); // SceneID digantikan dengan nama scene yang ingin kamu load
    }
}
