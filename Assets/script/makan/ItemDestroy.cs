using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class ItemDestroy : MonoBehaviour, IDropHandler
{
  // this is the script that will destroy the item when it is dropped in the mouth of the character will be reset the stamina in makan.cs 
  public void OnDrop(PointerEventData eventData)
  {
    Debug.Log("OnDrop");
    if (eventData.pointerDrag != null)
    {
      Destroy(eventData.pointerDrag);
      // logika pemanggilan reset stamina 
    }
  }
}

