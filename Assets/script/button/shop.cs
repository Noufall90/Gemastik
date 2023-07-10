using UnityEngine;
using UnityEngine.UI;

public class shop : MonoBehaviour
{
    public Button button1;

    // Start is called before the first frame update
    void Start()
    {
        button1.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("shop");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
