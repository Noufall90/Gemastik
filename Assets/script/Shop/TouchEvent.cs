using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class TouchEvent : MonoBehaviour
{
    public UnityEvent onTouch1 = new UnityEvent();
    public GameObject button1;
    // Start is called before the first frame update
    void Start()
    {
        button1 = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); // mengambil posisi mouse
        RaycastHit hit;
        if (Input.GetMouseButtonDown(0))
        {
          if(Physics.Raycast(ray,out hit) && hit.collider.gameObject == this.gameObject)
          {
            onTouch1.Invoke();
          }
        }
    }
}
