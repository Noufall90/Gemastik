using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float downwardSpeed = 5f; // Kecepatan ke bawah yang dapat diatur

    private void Update()
    {
        // Menggerakkan pemain ke bawah berdasarkan kecepatan downwardSpeed
        Vector3 newPosition = transform.position + Vector3.down * downwardSpeed * Time.deltaTime;
        transform.position = newPosition;
    }
}
