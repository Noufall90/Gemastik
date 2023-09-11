using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LibraryManager : MonoBehaviour
{
    [SerializeField] private GameObject _startingSceneTransition;

    // Start is called before the first frame update
    private void Start()
    {
        _startingSceneTransition.SetActive(true);
        StartCoroutine(DisableStartingSceneTransitionAfterDelay(0.2f));
    }

    private IEnumerator DisableStartingSceneTransitionAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay); // Menunggu selama 'delay' detik.
        _startingSceneTransition.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // Kode lainnya di sini
    }
}
