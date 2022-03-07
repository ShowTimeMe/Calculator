using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CalculatorTest : MonoBehaviour
{
    public InputField inputField;
    public Text text;
    public Button button;
    private string formulaStr;


    private int firstnum = 0;
    private int lastnum = 0;

    private List<string> data=new List<string>();

    private void Awake()
    {
        
    }
    private void Start()
    {
        text.text = "";
        button.onClick.AddListener(Oper);
    }

    public void Oper()
    {
        formulaStr = inputField.text;
        for (int i = 0; i < formulaStr.Length; i++)
        {
            data.Add(formulaStr[i].ToString());
        }
        for (int i = 0; i < data.Count; i++)
        {
            ForData();
        }
        for (int i = 0; i < data.Count; i++)
        {
            Debug.Log("数据:" + data[i] + "-----index:" + i);
        }
        text.text = "计算结果是：" + data[0];
    }

    public void ForData()
    {
        //string temporaryNum = "null";
        for (int i = 0; i < data.Count; i++)
        {
            if (IsOperation("/"))
            {
                if (data[i] == "/")
                {
                    Debug.Log("data:" + i);
                    ForWard(i);
                    float f = Convert.ToSingle(data[firstnum]) / Convert.ToSingle(data[lastnum]);
                    Debug.Log("firstnum" + firstnum + "lastnum" + lastnum);
                    data[firstnum] = f.ToString();
                    data[i] = "null";
                    data[lastnum] = "null";
                }
            }
            else if (IsOperation("*"))
            {
                if (data[i] == "*")
                {
                    Debug.Log("data:" + i);
                    ForWard(i);
                    float f = Convert.ToSingle(data[firstnum]) * Convert.ToSingle(data[lastnum]);
                    data[firstnum] = f.ToString();
                    data[i] = "null";
                    data[lastnum] = "null";
                }
            }
            else if (IsOperation("-"))
            {
                if (data[i] == "-")
                {
                    Debug.Log("data:" + i);
                    ForWard(i);
                    float f = Convert.ToSingle(data[firstnum]) - Convert.ToSingle(data[lastnum]);
                    data[firstnum] = f.ToString();
                    data[i] = "null";
                    data[lastnum] = "null";
                }
            }
            else if (IsOperation("+"))
            {
                if (data[i] == "+")
                {
                    Debug.Log("data:" + i);
                    ForWard(i);
                    float f = Convert.ToSingle(data[firstnum]) + Convert.ToSingle(data[lastnum]);
                    data[firstnum] = f.ToString();
                    data[i] = "null";
                    data[lastnum] = "null";
                }
            }

        }
    }
    /// <summary>
    /// 是否有运算符
    /// </summary>
    /// <returns></returns>
    public bool IsOperation(string s)
    {
        for (int i = 0; i < data.Count; i++)
        {
            if (data[i] == s)
            {
                return true;
            }
        }
        return false;
    }


    public void ForWard(int i)
    {
        Debug.Log("forward---:" + i);
        if (data[i - 1] == "null")
        {
            for (int index = i - 1; i > 0; index--)
            {
                
                if (data[index] != "null")
                {
                    firstnum = index;
                    break;
                }
            }
        }
        else
        {
            firstnum = i - 1;
        }
        if (data[i + 1] == "null")
        {
            for (int index = i + 1; i < data.Count; index++)
            {
                if (data[index] != "null")
                {
                    lastnum = index;
                    break;
                }
            }
        }
        else
        {
            lastnum = i + 1;
        }
    }

}
