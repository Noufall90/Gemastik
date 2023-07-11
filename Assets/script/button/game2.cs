using UnityEngine;
using UnityEngine.UI;

public class game3 : MonoBehaviour
{
    public Button button1;

    // Start is called before the first frame update
    void Start()
    {
        button1.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("game3");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
