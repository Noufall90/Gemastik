using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class CharacterSelect : MonoBehaviour
{
    public GameObject[] skins;
    public GameObject[] information;
    public int selectedCharacter = 0;
    public Character[] characters;
    public int selectedInformation = 0;

    public Button unlockButton;
    public TextMeshProUGUI kelerengText;
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
      UpdateUI();
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

        if (characters[selectedCharacter].isUnlocked)
        {
          PlayerPrefs.SetInt("SelectedCharacter", selectedCharacter);
          PlayerPrefs.SetInt("SelectedInformation", selectedInformation);
        }
      }
      else 
      {
        Debug.Log("Indeks di luar batas array!");
      }
      
      UpdateUI();
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

        if (characters[selectedCharacter].isUnlocked)
        {
          PlayerPrefs.SetInt("SelectedCharacter", selectedCharacter);
          PlayerPrefs.SetInt("SelectedInformation", selectedInformation);
        }
      }
      else 
      {
        Debug.Log("Indeks di luar batas array!");
      }
      UpdateUI();
    }

    public void UpdateUI()
    {
      kelerengText.text = PlayerPrefs.GetInt("Kelereng", 0).ToString();
      if (characters[selectedCharacter].isUnlocked == true)
      {
        unlockButton.gameObject.SetActive(false);
      }
      else 
      {
        unlockButton.GetComponentInChildren<TextMeshProUGUI>().text = "Price" + characters[selectedCharacter].price.ToString();
        if(PlayerPrefs.GetInt("Kelereng", 0) < characters[selectedCharacter].price)
        {
          unlockButton.gameObject.SetActive(true);
          unlockButton.interactable = false;
        }
        else 
        {
          unlockButton.gameObject.SetActive(true);
          unlockButton.interactable = true;
        }
      }
    }

    public void Unlock()
    {
      int coins = PlayerPrefs.GetInt("Kelereng", 0);
      int price = characters[selectedCharacter].price;
      PlayerPrefs.SetInt("Kelereng", coins - price);
      PlayerPrefs.SetInt(characters[selectedCharacter].name, 1);
      PlayerPrefs.SetInt("SelectedCharacter", selectedCharacter);
      characters[selectedCharacter].isUnlocked = true;
      UpdateUI();
    }
}
