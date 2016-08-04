/*
作者名称:YHB

脚本作用:格子的属性

建立时间:2016.8.4.16.03
*/

using UnityEngine;
using System.Collections;

public class Element : MonoBehaviour
{
    #region 字段
    public bool isMine;//表示是否是雷

    private SpriteRenderer spriteRenderer;
    #endregion

    #region Start生成地雷
    void Start()
    {
        spriteRenderer = this.GetComponent<SpriteRenderer>();

        isMine = Random.value <= 0.2f;//生成地雷的概率为20%

        int x = (int)this.transform.position.x;
        int y = (int)this.transform.position.y;

        Grid.element[x, y] = this;
    }
    void OnMouseUp()//判断点击事件
    {
        if (isMine)
        {
            //显示所有地雷，游戏结束--输了
            Grid.AllMines();
            Return._i.Los();
        }
        else
        {
            int x = (int)this.transform.position.x;
            int y = (int)this.transform.position.y;

            int mineCount = Grid.MineCount(x, y);
            Grid.FloodCover(x, y, new bool[Grid.w, Grid.h]);

            if (Grid.IsFinished())
            {
                Return._i.Win();
            }
        }
    }
    #endregion

    #region 显示图片的公共方法
    public void LoadTexture(int cont)
    {
        if (isMine)
        {
            spriteRenderer.sprite = ElementManager._i.mine;
        }
        else
        {
            spriteRenderer.sprite = ElementManager._i.texture[cont];
        }
    }
    #endregion

    #region 返回图片是否被点过
    public bool IsConvered()
    {
        return spriteRenderer.sprite.name == "def";
    }
    #endregion
}
