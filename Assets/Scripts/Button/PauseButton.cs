using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseButton : MonoBehaviour
{

    public void OnButtonClicked()
    {
        Time.timeScale = 1; // 恢复游戏时间缩放为正常值
    }

}