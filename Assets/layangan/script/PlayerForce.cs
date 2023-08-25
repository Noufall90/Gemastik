using UnityEngine;

public class PlayerForce : MonoBehaviour
{
    public float downwardForce = 10f; // Gaya ke bawah yang dapat diatur

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Menerapkan gaya ke bawah pada pemain
        Vector2 force = new Vector2(0, -downwardForce);
        rb.AddForce(force);
    }
}
