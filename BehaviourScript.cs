using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {
    private int turn = 1;//轮流
    private int[,] cell = new int[3, 3];//9方格
    private int result = 0;//结果，初始化为0,1为player1
    public Texture2D img1;//插入图片
    public Texture2D img2;
    void Start()
    {
        reset();
    }

    void reset()//初始化
    {
        result = 0;
        turn = 1;
        for (int i = 0; i < 3; i++)
            for (int j = 0; j < 3; j++)
                cell[i, j] = 0;
    }
    void Update()
    {   
        for(int i = 0;i < 3;i++)  //检查横向
        {
            Debug.Log("检查横向");
           if(cell[i,0] == cell[i, 1] &&cell[i,0]==cell[i, 2])
            {
                if (cell[i, 0] == 1)
                    result = 1;
                else if (cell[i, 0] == 2)
                    result = 2;
            }
        }

        for(int j = 0;j < 3;j++)   //检查纵向
            if(cell[0,j] == cell[1,j]&&cell[0,j] == cell[2,j])
            {
                Debug.Log("检查纵向");
                if (cell[0, j] == 1)
                    result = 1;
                if (cell[0, j] == 2)
                    result = 2;
            }

        if(cell[0,0]==cell[1,1]&&cell[0,0] == cell[2, 2])//检查两个斜边
        {
            Debug.Log("检查斜边");
            if (cell[0, 0] == 1)
                result = 1;
            if (cell[0, 0] == 2)
                result = 2;
        }
        if(cell[0,2] == cell[1,1]&&cell[0,2] == cell[2,0])
        {
            if (cell[0, 2] == 1)
                result = 1;
            if (cell[2, 0] == 1)
                result = 2;
        }
    }

    void OnGUI()
    {
        GUIStyle style1 = new GUIStyle();
        GUIStyle style2 = new GUIStyle();
        style1.normal.textColor = Color.blue;
        style2.normal.textColor = Color.red;
        style1.fontSize = 30;
        style1.fontStyle = FontStyle.Bold;
        style1.alignment = TextAnchor.MiddleCenter;
        style2.fontSize = 30;
        style2.fontStyle = FontStyle.Bold;
        style2.alignment = TextAnchor.MiddleCenter;
        GUI.contentColor = Color.yellow;
        string aa = "";

        //构造一个空的GUIStyle
        GUIStyle bb = new GUIStyle();

        //设置bb正常显示时是背景图片
        bb.normal.background = img1;
        GUI.Label(new Rect(0, 0, 800,400), aa, bb);

        if (GUI.Button(new Rect(10, 200, 100, 30), "reset")) 
        reset();
        if (result == 1)
            GUI.Label(new Rect(20, 250, 100, 50), "the boy wins!");
        else if (result == 2)
            GUI.Label(new Rect(20, 250, 100, 50), "the girl wins!");
        for(int i = 0;i < 3;i++)
            for(int j = 0;j < 3;j++)
            {
                if (cell[i, j] == 1)
                    GUI.Button(new Rect(i * 50, j * 50, 50, 50), "♂",style1);
                if (cell[i, j] == 2)
                    GUI.Button(new Rect(i * 50, j * 50, 50, 50), "♀",style2);
                if(GUI.Button(new Rect(i * 50, j * 50, 50, 50), ""))
                {
                    if(result == 0)
                    {
                        if (turn == 1)
                        {
                            cell[i, j] = 1;
                            turn = 2;
                        }
                        else if (turn == 2)
                        {
                            cell[i, j] = 2;
                            turn = 1;
                        }
                    }
                }
            }

    }
  

}
