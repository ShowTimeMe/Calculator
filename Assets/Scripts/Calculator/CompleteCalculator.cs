using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;

public class CompleteCalculator : MonoBehaviour
{
    public InputField inputField;
    public Text text;
    public Button button;
    private string formulaStr;

    private string selectNum = @"[0-9]+";
    private string[] operArray = {"/", "*", "-", "+"};


    private int firstnum = 0;// 第一个计算的数字index
    private int lastnum = 0; // 第二个计算的数字index
    private int operIndex = 0; //运算符index

    private List<string> data;
    private List<string> oper;

    private void Start()
    {
        button.onClick.AddListener(AddData);
    }

    public void AddData()
    {
        data=new List<string>();
        oper=new List<string>();
        
        formulaStr = inputField.text;
        //添加数据
        foreach (Match match in Regex.Matches(formulaStr, selectNum))
        {
            data.Add(match.Value);
        }

        //添加运算符
        foreach (var v in formulaStr)
        {
            foreach (var s in operArray)
            {
                if (v.ToString() == s)
                {
                    oper.Add(s);
                }
            }
        }

        // 计算  
        for (int i = 0; i < 100; i++)
        {
            Calculation();
        }
        text.text = "计算结果是：" + data[0];

        foreach (var v in data)
        {
            Debug.Log("data:"+v);
        }
        foreach (var v in oper)
        {
            Debug.Log("oper:"+v);
        }
    }

    public void Calculation()
    {
        for (int i = 0; i < oper.Count; i++)
        {
            if (IsOperation("/"))
            {
                FirstNum(operIndex);
                LastNum(operIndex);
                Debug.Log(data[firstnum] + "/" + data[lastnum] + "=========" + firstnum + "===========" + lastnum);
                float f = Convert.ToSingle(data[firstnum]) / Convert.ToSingle(data[lastnum]);
                Result(f.ToString());
            }
            else if(IsOperation("*"))
            {
                FirstNum(operIndex);
                LastNum(operIndex);
                Debug.Log(data[firstnum] + "*" + data[lastnum] + "=========" + firstnum + "===========" + lastnum);
                float f = Convert.ToSingle(data[firstnum]) * Convert.ToSingle(data[lastnum]);
                Result(f.ToString());
            }
            else if(IsOperation("+"))
            {
                FirstNum(operIndex);
                LastNum(operIndex);
                Debug.Log(data[firstnum] + "+" + data[lastnum] + "=========" + firstnum + "===========" + lastnum);
                float f = Convert.ToSingle(data[firstnum]) + Convert.ToSingle(data[lastnum]);
                Result(f.ToString());
            }
            else if(IsOperation("-"))
            {
                FirstNum(operIndex);
                LastNum(operIndex);
                Debug.Log(data[firstnum] + "-" + data[lastnum] + "=========" + firstnum + "===========" + lastnum);
                float f = Convert.ToSingle(data[firstnum]) - Convert.ToSingle(data[lastnum]);
                Result(f.ToString());
            }
        }
    }
    
    /// <summary>
    /// 是否有运算符
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    public bool IsOperation(string s)
    {
        for (int i = 0; i < oper.Count; i++)
        {
            if (oper[i] == s)
            {
                operIndex = i;
                Debug.Log("operIndex:==="+operIndex);
                return true;
            }
        }
        return false;
    }

    public void FirstNum(int index)
    {
        if (index == 0)
        {
            firstnum = 0;
            return;
        }
        for (int i = index; i >0 ; i--)
        {
            if (data[i] != "null")
            {
                firstnum = i;
                return;
            }
        }
    }

    public void LastNum(int index)
    {
        if (index == data.Count)
        {
            lastnum = data.Count;
            return;
        }
        
        for (int i = index + 1; i < data.Count ; i++)
        {
            if (data[i] != "null")
            {
                lastnum = i;
                Debug.Log("LastNum" + lastnum + "data:" + data[lastnum]);
                return;
            }
        }
    }


    public void Result(string str)
    {
        data[firstnum] = str;
        data[lastnum] = "null";
        oper[operIndex] = "null";
    }
}
