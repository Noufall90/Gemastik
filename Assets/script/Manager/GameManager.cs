using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    // Variabel untuk menyimpan data persisten
    public float currentStamina;
    public float timeCounter;
    private float maxStamina = 100f; // Nilai maksimum stamina

    private void Awake()
    {
        // Membuat singleton instance dari GameManager
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ResetStamina()
    {
      // Reset timeCounter dan currentStamina ke nilai awal
      timeCounter = 0f;
      currentStamina = maxStamina; // Reset stamina ke nilai maksimum
    }

    // private void Start()
    // {
    //   LoadGameData();
    // }
    //
    // private void OnApplicationQuit()
    // {
    //   SaveGameData();
    // }
    //
    // private void OnApplicationPause(bool pauseStatus)
    // {
    //   if (pauseStatus)
    //   {
    //     SaveGameData();
    //   }
    // }
    // public void ResetStamina()
    // {
    //     currentStamina = maxStamina; // Menyetel ulang stamina ke maxStamina
    // }
    //
    // private void SaveGameData()
    // {
    //   PlayerPrefs.SetFloat("CurrentStamina", currentStamina);
    //   PlayerPrefs.Save();
    //
    //   Debug.Log("Data Permainan telah disimpan");
    // }
    //
    // private void LoadGameData()
    // {
    //    if (PlayerPrefs.HasKey("CurrentStamina"))
    //     {
    //         currentStamina = PlayerPrefs.GetFloat("CurrentStamina");
    //         Debug.Log("Data permainan telah dimuat.");
    //     }
    // }
}
