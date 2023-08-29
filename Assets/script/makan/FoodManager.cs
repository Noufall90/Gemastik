using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodManager : MonoBehaviour
{
    public GameObject[] foodPrefabs;
    int foodIndex;

    // Start is called before the first frame update
    private void Awake()
    {
        foodIndex = PlayerPrefs.GetInt("SelectedFood", 0 );
        Instantiate(foodPrefabs[foodIndex]);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
