using UnityEngine;
using UnityEngine.UI;

public class btnmandi : MonoBehaviour
{
    public Button button2;

    // Start is called before the first frame update
    void Start()
    {
        button2.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("mandi");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
