using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSelection : MonoBehaviour
{
    public GameObject[] food;
    public int SelectedFood;
    // Start is called before the first frame update
    private void Awake()
    {
        SelectedFood = PlayerPrefs.GetInt("SelectedFood", 0);
        foreach (GameObject meal in food){
            meal.SetActive(false);
        }

        food[SelectedFood].SetActive(true);
    }

    public void ChangeNext()
    {
        food[SelectedFood].SetActive(false);
        SelectedFood++;
        if(SelectedFood == food.Length)
            SelectedFood = 0;
        food[SelectedFood].SetActive(true);
        PlayerPrefs.SetInt("SelectedFood", SelectedFood);
    }

     public void ChangePrevious()
    {
        food[SelectedFood].SetActive(false);
        SelectedFood--;
        if(SelectedFood == -1)
            SelectedFood = food.Length -1;
        food[SelectedFood].SetActive(true);
        PlayerPrefs.SetInt("SelectedFood", SelectedFood);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
