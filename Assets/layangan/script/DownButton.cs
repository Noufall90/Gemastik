using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DownkButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    bool isPressed = false;
    public GameObject Player;
    public float Force;

    // Update is called once per frame
    void Update()
    {
        if (isPressed)
        {
            Vector3 movement = new Vector3(0, 0, Force);
            Player.transform.Translate(movement * Time.deltaTime);
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isPressed = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isPressed = false;
    }
}
