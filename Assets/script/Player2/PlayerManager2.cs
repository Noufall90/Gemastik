using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerManager2 : MonoBehaviour
{
    public static bool gameOver;
    public GameObject gameOverPanel;

    public static bool isGameStarted;
    public GameObject startingText;

    public static int numbOfKelereng;

    public Text kelerengText;

    // Start is called before the first frame update
    void Start()
    {
        gameOver = false;

        Time.timeScale = 1;
        isGameStarted = false;

        numbOfKelereng = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver)
        {
            Time.timeScale = 0;
            gameOverPanel.SetActive(true);
        }

        kelerengText.text = "Kelereng: " + numbOfKelereng;

        if (SwipeManager.tap && !isGameStarted)
        {
            isGameStarted = true;
            Destroy(startingText);
        }
    }
}
