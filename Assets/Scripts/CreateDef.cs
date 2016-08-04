/*
作者名称:YHB

脚本作用:自动生成格子

建立时间:2016.8.4.16.03
*/

using UnityEngine;
using System.Collections;

public class CreateDef : MonoBehaviour
{
    #region 字段
    public GameObject prefab;
    public int rowNum = 20;//行
    public int colNum = 30;//列
    #endregion

    #region  初始执行
    void Start()
    {
        Create();
    }
    #endregion

    #region 生成格子
    void Create()
    {
        for (int i = 0; i < colNum; i++)
        {
            for (int j = 0; j < rowNum; j++)
            {
                GameObject go = Instantiate(prefab, this.transform.position + new Vector3(i, j, 0), Quaternion.identity) as GameObject;
                go.transform.parent = this.transform;
            }
        }
    }
    #endregion
}
