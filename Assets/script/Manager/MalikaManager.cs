using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MalikaManager : MonoBehaviour
{
    public static Vector3 lastCheckPointPos;
    public GameObject[] playerPrefabs;
    int characterIndex;

    public static int numbOfKelereng;
    public Text kelerengText;
    // Start is called before the first frame update
    void Start()
    {
        // Identifikasi posisi karakter
        lastCheckPointPos = new Vector3 (555, 235, 218);
        transform.rotation = Quaternion.identity;
        Quaternion newRotation = Quaternion.Euler(0, 180, 0);
        transform.rotation = newRotation;

        characterIndex = PlayerPrefs.GetInt("SelectedCharacter", 0);

        Instantiate(playerPrefabs[characterIndex], lastCheckPointPos, transform.rotation);

        numbOfKelereng = PlayerPrefs.GetInt("Kelereng", 0);
    }

    // Update is called once per frame
    void Update()
    {
        kelerengText.text =  numbOfKelereng.ToString();
    }
}
