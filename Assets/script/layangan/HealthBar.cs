using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public static event Action<Enemy> OnEnemyKilled;
    [SerializeField]float health, maxHealth = 3f;

    [SerializeField] float moveSpeed;
    Rigidbody2D rb;
    Transform target;
    Vector2 moveDirection;

    [SerializeField] HealthBar healthbar;
    // Start is called before the first frame update
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        healthbar = GetComponentInChildrent<HealthBar>()1;
    }
    private void Start()
    {
        health = maxHealth;
        target= GameObject.Find("player").transform
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
