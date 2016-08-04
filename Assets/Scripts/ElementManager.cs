/*
作者名称:YHB

脚本作用:图片管理器

建立时间:2016.8.4.16.38
*/

using UnityEngine;
using System.Collections;

public class ElementManager : MonoBehaviour
{
    #region 字段
    public Sprite[] texture;
    public Sprite mine;
    #endregion

    #region 单例
    public static ElementManager _i;
    void Awake()
    {
        _i = this;
    }
    #endregion
}
