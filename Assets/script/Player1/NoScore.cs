using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class noscore : MonoBehaviour
{
    public static int ScoreValue = 0;
    Text scoreText;

    void Start()
    {
        scoreText = GetComponent<Text>();
    }

    void Update()
    {
        scoreText.text = "Lompat: " + ScoreValue; // Perbarui teks skor
    }
}

