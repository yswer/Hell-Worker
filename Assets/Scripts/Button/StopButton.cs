using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopButton : MonoBehaviour
{
    public void OnButtonClicked()
    {
        Time.timeScale = 0;
    }
}
