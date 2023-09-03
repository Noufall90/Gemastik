using UnityEngine;
using UnityEngine.UI;

public class StaminaWheel : MonoBehaviour
{
    
    public float maxStamina = 100f; // Nilai maksimum stamina
    public Slider usageWheel; // Slider untuk menampilkan penggunaan stamina

    private float decrementRate; // Pengurangan stamina per detik

    private Color originalColor = new Color(0.3804f, 0.9255f, 0.1176f); // Warna asli slider (61EC1E)
    private Color redColor = Color.red; // Warna merah
    private Color yellowColor = Color.yellow; // Warna kuning

    private float currentStamina = 0f; // Variabel stamina saat ini

    private bool isButtonPressed = false; // Status tombol

    void Start()
    {
        // Mengambil nilai stamina terakhir dari GameManager
        currentStamina = PlayerPrefs.GetFloat("RoomStamina");
        decrementRate = maxStamina / 500f; // Menghitung pengurangan stamina per detik (60 detik = 1 menit)


    }

    void Update()
    {
        currentStamina = Mathf.Max(currentStamina - (decrementRate * Time.deltaTime), 0f); // Mengurangi stamina dengan pengurangan per detik

        Debug.Log("Current Stamina: " + currentStamina);

        if (usageWheel != null)
        {
            usageWheel.value = (currentStamina / maxStamina) + 0f;

            if (currentStamina >= 25 && currentStamina <= 50) // Ketika angka berada di detik 10 atau lebih
            {
                ChangeSliderColor(yellowColor); // Ubah warna slider menjadi merah
            }
            else if (currentStamina <= 25)
            {
                ChangeSliderColor(redColor); // Ubah warna slider menjadi kuning
            }
            else
            {
                ChangeSliderColor(originalColor); // Kembalikan warna slider ke warna asli
            }
        }

        if (currentStamina <= 0)
        {
            // Lakukan tindakan ketika stamina habis
        }
        
        if (isButtonPressed)
        {
            // Reset timeCounter dan currentStamina ke nilai awal
            currentStamina = maxStamina; // Reset stamina ke nilai maksimum
            isButtonPressed = false; // Reset status tombol
            PlayerPrefs.SetFloat("RoomStamina", currentStamina);
            PlayerPrefs.Save();
        }
    }
    
    public void ResetStamina()
    {
      // Reset timeCounter dan currentStamina ke nilai awal
      currentStamina = maxStamina; // Reset stamina ke nilai maksimum
      PlayerPrefs.SetFloat("RoomStamina", currentStamina);
      PlayerPrefs.Save();
    }

    private void ChangeSliderColor(Color color)
    {
        if (usageWheel != null)
        {
            var fillRect = usageWheel.fillRect;
            if (fillRect != null)
            {
                var fillImage = fillRect.GetComponent<Image>();
                if (fillImage != null)
                {
                    fillImage.color = color;
                }
            }
        }
    }

    private void OnDestroy()
    {
        // Menyimpan nilai stamina ke GameManager saat objek dihancurkan
        PlayerPrefs.SetFloat("RoomStamina", currentStamina);
        PlayerPrefs.Save(); 
    }

    public void OnResetButtonPressed()
    {
      isButtonPressed = true;
    }
}
