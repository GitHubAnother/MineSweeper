/*
作者名称:YHB

脚本作用:用来点击按钮切换到游戏场景

建立时间:2016.8.4.18.31
*/

using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour
{
    //按钮事件
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }
}
