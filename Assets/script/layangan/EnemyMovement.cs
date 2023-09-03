using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField]
    float speed;
    [SerializeField]
    float range;
    [SerializeField]
    float maxDistance; // Saya menambahkan tanda titik koma (;) di sini

    Vector2 waypoint;

    // Start is called before the first frame update
    void Start()
    {
        SetNewDestination();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, waypoint, speed * Time.deltaTime); // Saya mengubah "MoveToward" menjadi "MoveTowards" dan "positon" menjadi "position"
        if (Vector2.Distance(transform.position, waypoint) < range) // Saya mengubah "positon" menjadi "position"
        {
            SetNewDestination();
        }
    }

    void SetNewDestination()
    {
        waypoint = new Vector2(Random.Range(-maxDistance, maxDistance), Random.Range(-maxDistance, maxDistance));
    }
}
