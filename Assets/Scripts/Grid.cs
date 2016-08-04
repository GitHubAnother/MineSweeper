/*
作者名称:YHB

脚本作用:格子逻辑的控制

建立时间:2016.8.4.17.41
*/

using UnityEngine;
using System.Collections;

public class Grid : MonoBehaviour
{
    #region 静态字段
    public static int w = 30, h = 20;

    public static Element[,] element = new Element[w, h];

    #endregion

    #region 静态方法
    public static void AllMines()
    {
        foreach (Element e in element)
        {
            if (e.isMine)
            {
                e.LoadTexture(0);
            }
        }
    }

    public static bool MineAt(int x, int y)//返回当前格子是否是地雷
    {
        if (x >= 0 && y >= 0 && x < w && y < h)
        {
            return element[x, y].isMine;
        }

        return false;
    }

    public static int MineCount(int x, int y)//返回地雷数量,用来生成周围有几个地雷的图片
    {
        int count = 0;

        if (MineAt(x, y + 1)) count++;//正上
        if (MineAt(x, y - 1)) count++;//正下

        if (MineAt(x - 1, y)) count++;//正左
        if (MineAt(x + 1, y)) count++;//正右

        if (MineAt(x - 1, y + 1)) count++;//左上
        if (MineAt(x - 1, y - 1)) count++;//左下

        if (MineAt(x + 1, y + 1)) count++;//右上
        if (MineAt(x + 1, y - 1)) count++;//右下

        return count;
    }

    public static void FloodCover(int x, int y, bool[,] visites)//算法---连续的0号图片全部显示
    {
        if (x >= 0 && y >= 0 && x < w && y < h)
        {
            //利用递归去查找每个格子上下左右是不是相同的0号图片，是的话就都打开
            if (visites[x, y])
            {
                return;
            }

            visites[x, y] = true;

            element[x, y].LoadTexture(MineCount(x, y));//打开来

            if (MineCount(x, y) > 0)
            {
                return;//遇到数字图片就不查找了
            }

            FloodCover(x - 1, y, visites);
            FloodCover(x + 1, y, visites);
            FloodCover(x, y - 1, visites);
            FloodCover(x, y + 1, visites);
        }
    }

    public static bool IsFinished()//判断游戏是否结束
    {
        foreach (Element e in element)
        {
            if (e.IsConvered() && !e.isMine)//格子还没点 并且不是地雷
            {
                return false;
            }
        }

        return true;//表示游戏结束了赢了
    }
    #endregion

}
