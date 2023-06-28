using UnityEngine;
using UnityEngine.UI;

public class StaminaWheel : MonoBehaviour
{
    public float maxStamina = 100f; // Nilai maksimum stamina
    public float stamina; // Stamina saat ini
    public Slider usageWheel; // Slider untuk menampilkan penggunaan stamina

    private float decrementRate; // Pengurangan stamina per detik
    private float timeCounter = 0f; // Penghitung waktu

    void Start()
    {
        stamina = maxStamina;
        decrementRate = maxStamina / 300f; // Menghitung pengurangan stamina per detik (60 detik = 1 menit)
    }

    void Update()
    {
        timeCounter += Time.deltaTime;

        stamina = Mathf.Max(stamina - (decrementRate * Time.deltaTime), 0f); // Mengurangi stamina dengan pengurangan per detik

        if (usageWheel != null)
        {
            usageWheel.value = (stamina / maxStamina) + 0f;
        }

        if (stamina <= 0)
        {
            // Lakukan tindakan ketika stamina habis
        }
    }
}
