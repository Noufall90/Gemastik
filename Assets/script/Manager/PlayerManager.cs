using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class PlayerManager : MonoBehaviour
{
    public static bool gameOver;
    public GameObject gameOverPanel;

    public static bool isGameStarted;
    public GameObject startingText;
 
    public static int numbOfKelereng;
    public TextMeshProUGUI kelerengText;
    // Start is called before the first frame update
    private void Awake()
    {

        gameOver = false;
        numbOfKelereng = PlayerPrefs.GetInt("Kelereng", 0);

        Time.timeScale = 1;
        isGameStarted = false; 
    } 
    // Update is called once per frame
    void Update()
    {
        if (gameOver)
        {
            Time.timeScale = 0;
            gameOverPanel.SetActive(true);
        }

        kelerengText.text = numbOfKelereng.ToString();

        if (SwipeManager.tap && !isGameStarted)
        {
            isGameStarted = true;
            Destroy(startingText);
        }
    }
}
