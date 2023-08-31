using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MalikaFoodRoomManager : MonoBehaviour
{
    public static Vector3 lastCheckPointPos;
    public GameObject[] playerPrefabs;
    int characterIndex;
    // Start is called before the first frame update
    void Start()
    {
        lastCheckPointPos = new Vector3 (555, 235, 600);
        transform.rotation = Quaternion.identity;
        Quaternion newRotation = Quaternion.Euler(0, 180, 0);
        transform.rotation = newRotation;

        characterIndex = PlayerPrefs.GetInt("SelectedCharacter", 0);

        Instantiate(playerPrefabs[characterIndex], lastCheckPointPos, transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
