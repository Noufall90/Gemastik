using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public float timeRemaining = 60; // Waktu awal
    public bool timeIsRunning = true;
    public TMP_Text timeText;

    // Start is called before the first frame update
    void Start()
    {
        timeIsRunning = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeIsRunning)
        {
            if (timeRemaining > 0) // Ubah tanda '>=' menjadi '>'
            {
                timeRemaining -= Time.deltaTime; // Kurangi waktu sisa
                DisplayTime(timeRemaining); // Panggil fungsi DisplayTime
            }
            else
            {
                timeIsRunning = false;
                timeRemaining = 0;
                // Tambahkan kode di sini untuk menangani ketika waktu habis
            }
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60); // Ubah ke 'timeToDisplay % 60'
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
