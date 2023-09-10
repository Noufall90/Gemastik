using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class touchButton : MonoBehaviour
{
    public UnityEvent onTouch = new UnityEvent();
    public GameObject button;
    // Start is called before the first frame update
    void Start()
    {
        button = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
          UnityEngine.Touch touch = Input.GetTouch(0);

          if(touch.phase == TouchPhase.Began)
          {
            Ray ray = Camera.main.ScreenPointToRay(touch.position); // mengambil posisi mouse
            RaycastHit hit;
            if(Physics.Raycast(ray,out hit) && hit.collider.gameObject == gameObject)
            {
              onTouch.Invoke();
              Debug.Log("sentuh");
              Debug.Log(touch);
            }
          }
        }
    }
}
