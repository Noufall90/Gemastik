using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetDataManager2 : MonoBehaviour
{
    public int initialKelerengValue = 0;
    public void ResetData()
    {
      PlayerPrefs.SetInt("Kelereng", initialKelerengValue);
    }
}
