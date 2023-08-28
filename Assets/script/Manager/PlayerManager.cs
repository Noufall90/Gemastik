using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static bool gameOver;
    public GameObject gameOverPanel;

    public static bool isGameStarted;
    public GameObject startingText;

    public static Vector3 lastCheckPointPos;
    public static int numbOfKelereng;
    public Text kelerengText;
    
    public GameObject[] playerPrefabs;
    int characterIndex;
    // Start is called before the first frame update
    private void Awake()
    {
        lastCheckPointPos = new Vector3 (555, 235, 218);
        transform.rotation = Quaternion.identity;
        Quaternion newRotation = Quaternion.Euler(0, 180, 0);
        transform.rotation = newRotation;
        
        characterIndex = PlayerPrefs.GetInt("SelectedCharacter", 0);

        Instantiate(playerPrefabs[characterIndex], lastCheckPointPos, transform.rotation);
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

        kelerengText.text =  numbOfKelereng.ToString();

        if (SwipeManager.tap && !isGameStarted)
        {
            isGameStarted = true;
            Destroy(startingText);
        }
    }
}
