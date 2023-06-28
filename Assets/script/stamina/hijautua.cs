using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class updateStaminaWheel : MonoBehaviour
{
    public float maxStamina = 100f; // Nilai maksimum stamina
    public float stamina; // Stamina saat ini
    public Slider usageWheel; // Slider untuk menampilkan penggunaan stamina

    private float decrementRate; // Pengurangan stamina per detik
    private bool isDelaying = false; // Status penundaan
    private WaitForSeconds delayDuration = new WaitForSeconds(5f); // Durasi penundaan

    void Start()
    {
        stamina = maxStamina;
        decrementRate = maxStamina / 300f; // Menghitung pengurangan stamina per detik (60 detik = 1 menit)
    }

    void Update()
    {
        if (!isDelaying)
        {
            stamina = Mathf.Max(stamina - (decrementRate * Time.deltaTime), 0f); // Mengurangi stamina dengan pengurangan per detik
        }

        if (usageWheel != null)
        {
            usageWheel.value = (stamina / maxStamina) + 0.05f;
        }

        if (stamina <= 0)
        {
            // Lakukan tindakan ketika stamina habis
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            StartCoroutine(DelayCoroutine());
        }
    }

    IEnumerator DelayCoroutine()
    {
        isDelaying = true;
        yield return delayDuration;
        isDelaying = false;
    }
}
