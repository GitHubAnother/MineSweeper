/*
作者名称:YHB

脚本作用:

建立时间:
*/

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Return : MonoBehaviour
{
    #region 字段
    private GameObject image;
    private GameObject btn1;
    private GameObject btn2;
    #endregion

    #region 单例
    public static Return _i;
    void Awake()
    {
        _i = this;
    }
    #endregion

    #region 初始化
    void Start()
    {
        image = this.transform.FindChild("Image").gameObject;
        btn1 = this.transform.FindChild("Button1").gameObject;
        btn2 = this.transform.FindChild("Button2").gameObject;

        image.SetActive(false);
        btn1.SetActive(false);
        btn2.SetActive(false);
    }
    #endregion

    public void Los()//输了
    {
        image.SetActive(true);
        btn1.SetActive(true);
    }

    public void Win()//赢了
    {
        image.GetComponent<Image>().color = new Color(0, 1, 1, 0.45f);
        image.SetActive(true);
        btn2.SetActive(true);
    }

    //按钮方法
    public void ReturnMain()
    {
        Application.LoadLevel(0);
    }
}
