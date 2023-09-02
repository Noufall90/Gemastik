using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelect : MonoBehaviour
{
    public GameObject[] skins;
    public GameObject[] information;
    public int selectedCharacter = 0;
    public Character[] characters;
    public int selectedInformation = 0;
    // Start is called before the first frame update
    
    private void Awake()
    {
      selectedCharacter = PlayerPrefs.GetInt("SelectedCharacter", 0);
      selectedInformation = PlayerPrefs.GetInt("SelectedInformation", 0); 
      foreach (GameObject player in skins)
      {
        player.SetActive(false);
      }

      skins[selectedCharacter].SetActive(true);
      information[selectedInformation].SetActive(true);

      foreach(Character c in characters)
      {
        if(c.price == 0)
          c.isUnlocked = true;
        else 
        { 
          c.isUnlocked = PlayerPrefs.GetInt(c.name, 0) == 0 ? false : true;
        }
      }
    }
    
    public void ChangeNext()
    {
      if (selectedCharacter >= 0 && selectedCharacter < skins.Length && selectedInformation >= 0 && selectedInformation < information.Length)
      {
        skins[selectedCharacter].SetActive(false);
      information[selectedInformation].SetActive(false);
      selectedCharacter++;
      selectedInformation++;
      if (selectedCharacter == skins.Length)
      {
        selectedCharacter = 0;
        selectedInformation = 0;
      }
      skins[selectedCharacter].SetActive(true);
      information[selectedInformation].SetActive(true);
      PlayerPrefs.SetInt("SelectedCharacter", selectedCharacter);
      PlayerPrefs.SetInt("SelectedInformation", selectedInformation);
      }
      else 
      {
        Debug.Log("Indeks di luar batas array!");
      }
    }

    public void ChangePrevious()
    {
      if (selectedCharacter >= 0 && selectedCharacter < skins.Length && selectedInformation >= 0 && selectedInformation < information.Length)
      {
      skins[selectedCharacter].SetActive(false);
      information[selectedInformation].SetActive(false);
      selectedCharacter--;
      selectedInformation--;
      if (selectedCharacter == -1)
      {
        selectedCharacter = skins.Length - 1;
        selectedInformation = skins.Length - 1;
      }
      skins[selectedCharacter].SetActive(true);
      information[selectedInformation].SetActive(true);
      PlayerPrefs.SetInt("SelectedCharacter", selectedCharacter);
      PlayerPrefs.SetInt("SelectedInformation", selectedInformation);
      }
      else 
      {
        Debug.Log("Indeks di luar batas array!");
      }
    }
}
