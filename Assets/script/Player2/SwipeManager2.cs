using UnityEngine;

public class SwipeManager2 : MonoBehaviour
{
    public static bool tap, swipeLeft, swipeRight, swipeUp, swipeDown;
    private bool tapRequested;
    private bool isDraging = false;
    private Vector2 startTouch, swipeDelta;

    private void Update()
    {
        tap = swipeDown = swipeUp = swipeLeft = swipeRight = false;
        #region Standalone Inputs 
        if (Input.GetMouseButtonDown(0)) // Jika diklik maka akan true
        {
            tap = isDraging = true;
            startTouch = Input.mousePosition;
    
        }
        else if (Input.GetMouseButton(1)){
          Debug.Log("Left Click");
        }
        else if (Input.GetMouseButtonUp(0)) // Jika dilepas maka akan false
        {
            isDraging = false;
            Reset();
        }
        #endregion

        #region Mobile Input
        if (Input.touches.Length > 0) // Mengindikasikan bahwa ada sentuhan pada layar
        {
            if (Input.touches[0].phase == TouchPhase.Began) // Jika sentuhan pertama kali
            { // Jika disentuh maka akan true 
                tap = isDraging = true; // sentuhan yang ditahan dan menandakan bahwa sedang di drag atau swipe
                startTouch = Input.touches[0].position; // Mengambil posisi sentuhan pertama kali
                 
            }
            else if (Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled)
            { // Jika sentuhan dilepas atau dibatalkan
                isDraging = false; // sentuhan yang dilepas atau dibatalkan dan menandakan bahwa tidak sedang di drag atau swipe
                Reset(); // Mengembalikan nilai awal
            }
        }
        #endregion

        //Calculate the distance
        swipeDelta = Vector2.zero; // Menginisialisasi nilai awal pada swipeDelta (0,0,0)
        if (isDraging) // Jika sedang di drag atau swipe
        {
            if (Input.touches.Length > 0) // Jika ada sentuhan pada layar
                swipeDelta = Input.touches[0].position - startTouch; // Menghitung jarak antara sentuhan pertama kali dengan sentuhan yang ditahan
            else if (Input.GetMouseButton(0)) // Jika diklik
                swipeDelta = (Vector2)Input.mousePosition - startTouch; // Menghitung jarak antara sentuhan pertama kali dengan sentuhan yang ditahan
        }

        //Did we cross the distance?
        if (swipeDelta.magnitude > 100) // Jika jaraknya lebih dari 100
        {
            //Which direction?
            float x = swipeDelta.x; // Menyimpan komponen horizontal(x) di variable x
            float y = swipeDelta.y; // Menyimpan komponen vertikal(y) di variable y

            if (Mathf.Abs(x) > Mathf.Abs(y)) // Jika nilai absolut dari x lebih besar dari nilai absolut dari y maka true
            {
                //Left or Right
                if (x < 0) // Jika x kurang dari 0 maka swipe ke kiri
                    swipeLeft = true;
                else // Jika x lebih dari 0 maka swipe ke kanan
                    swipeRight = true;
            }
            else
            {
                //Up or Down
                if (y < 0) 
                    swipeDown = true;
                else 
                    swipeUp = true; 
            }
            //
            Reset();
        }

    }

    private void Reset()
    {
        startTouch = swipeDelta = Vector2.zero;
        isDraging = false;
    }
}

