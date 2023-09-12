using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextOp : MonoBehaviour
{
    // Start is called before the first frame update
    void OnEnable()
    {
        SceneManager.LoadScene("Opening", LoadSceneMode.Single);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}