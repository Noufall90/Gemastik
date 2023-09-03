using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] // Corrected the attribute name to "SerializeField"
    private GameObject musuhPrefab;

    [SerializeField] // Corrected the attribute name to "SerializeField"
    private float musuhInterval = 5f; // Corrected the attribute type to "float"

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemy(musuhInterval, musuhPrefab)); // Corrected the method name
    }

    // Update is called once per frame
    private IEnumerator SpawnEnemy(float interval, GameObject enemy) // Corrected the return type and parameter type
    {
        yield return new WaitForSeconds(interval); // Corrected the yield statement
        GameObject newEnemy = Instantiate(enemy, new Vector3(Random.Range(-100f, 100f), Random.Range(-80f, 80f), 0), Quaternion.identity);
        StartCoroutine(SpawnEnemy(interval, enemy)); // Recursive call to keep spawning enemies
    }
}
