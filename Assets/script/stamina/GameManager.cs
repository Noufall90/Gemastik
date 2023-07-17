using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    // Variabel untuk menyimpan data persisten
    public float currentStamina;

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
        currentStamina = maxStamina; // Menyetel ulang stamina ke maxStamina
    }
}
