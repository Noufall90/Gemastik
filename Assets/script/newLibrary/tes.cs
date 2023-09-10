using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tes : MonoBehaviour
{
    /* public Button button; */

    public void buttonMethod()
    {
       Debug.Log("Button Clicked");
       TaskOnClick();
       /* button.onClick.AddListener(TaskOnClick); */
    } 

    private void TaskOnClick()
    {
       UnityEngine.SceneManagement.SceneManager.LoadScene("library");
    }
}
