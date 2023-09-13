using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSelection : MonoBehaviour
{
    public GameObject[] food;
    public GameObject[] info;
    public int selectedFood = 0;
    public int selectedInfo = 0;
    // Start is called before the first frame update
    private void Awake()
    {
        selectedFood = PlayerPrefs.GetInt("SelectedFood", 0);
        selectedInfo = PlayerPrefs.GetInt("SelectedInfo", 0);
        foreach (GameObject meal in food){
            meal.SetActive(false);
        }

        food[selectedFood].SetActive(true);
        info[selectedInfo].SetActive(true);
    }

    public void ChangeNext()
    {   
      if(selectedFood >= 0 && selectedFood < food.Length && selectedInfo >= 0 && selectedInfo < info.Length)
      {
        food[selectedFood].SetActive(false);
        info[selectedInfo].SetActive(false);
        selectedFood++;
        selectedInfo++;
        if(selectedFood == food.Length)
        {
          selectedFood = 0;
          selectedInfo = 0;
        }
        food[selectedFood].SetActive(true);
        info[selectedInfo].SetActive(true);
        PlayerPrefs.SetInt("SelectedFood", selectedFood);
        PlayerPrefs.SetInt("SelectedInfo", selectedInfo);
      }
      else 
      {
        Debug.Log("indeks di luar batas array");
      }
    }

     public void ChangePrevious()
    {
        if (selectedFood >= 0 && selectedFood < food.Length && selectedInfo >= 0 && selectedInfo < info.Length)
        {
        food[selectedFood].SetActive(false);
        info[selectedInfo].SetActive(false);
        selectedFood--;
        selectedInfo--;
        if(selectedFood == -1)
        {
            selectedFood = food.Length -1;
            selectedInfo = info.Length -1;
        }
        food[selectedFood].SetActive(true);
        info[selectedInfo].SetActive(true);
        PlayerPrefs.SetInt("SelectedFood", selectedFood);
        PlayerPrefs.SetInt("SelectedInfo", selectedInfo);
        }
        else 
        {
            Debug.Log("indeks di luar batas array");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
