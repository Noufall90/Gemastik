using UnityEngine;
using UnityEngine.EventSystems;

public class MySwipeUpHandler : MonoBehaviour, IDragHandler, IEndDragHandler
{
    private Vector2 swipeStartPos;
    private float swipeMinDistance = 50f; // Sesuaikan jarak minimum yang diperlukan untuk dianggap sebagai swipe

    public void OnDrag(PointerEventData eventData)
    {
        // Tangkap posisi awal saat pemain mulai menggeser
        if (eventData.delta.y > 0)
        {
            swipeStartPos = eventData.position;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // Hitung jarak vertikal yang diterima pemain saat menggeser
        float swipeDistance = eventData.position.y - swipeStartPos.y;

        // Jika jarak lebih besar dari jarak minimum, lakukan swipe atas
        if (Mathf.Abs(swipeDistance) >= swipeMinDistance)
        {
            OnSwipeUp();
        }
    }

    private void OnSwipeUp()
    {
        // Putar animasi di sini
        GetComponent<Animator>().Play("MyAnimation");
    }
}
