using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class Calculator : MonoBehaviour
{

    public InputField inputField;
    public Text text;
    public Button button;
    private string formulaStr;

    private float firstnum = 0;
    private float lastnum = 0;


    private string previousStr ;
    private string lastStr ;

    private string num = @"\d+";
    // Start is called before the first frame update

    private void Awake()
    {
        text.text = "";
        button.onClick.AddListener(Test);
    }


    private void Update()
    {
        
    }

    public void Btn()
    {
        DataTable dt = new DataTable();
        if (inputField.text != "")
        {
            string value = inputField.text;
            string result = dt.Compute(value, null).ToString();
            //Debug.Log("计算结果" + dt.Compute(value, null));
            text.text = result;
        }
        else
        {
            text.text = "请输入";
            Debug.Log("请输入");
        }
        
    }



    public void String()
    {
        
        formulaStr = inputField.text;
        firstnum = 0;
        lastnum = 0;
        Debug.Log(formulaStr);
        foreach (char c in formulaStr)
        {
            if (formulaStr.Contains("/"))
            { 
                previousStr = @"(\d+)/";
                lastStr = @"/(\d+)";
                Except();
                Debug.Log(firstnum + "---" + lastnum);
                formulaStr= formulaStr.Replace(firstnum+"/"+lastnum, (firstnum / lastnum).ToString());
                Debug.Log(formulaStr);
            }
            else 
            {
                if (formulaStr.Contains("-"))
                {
                    previousStr = @"(\d+)-";
                    lastStr = @"-(\d+)";
                    Except();
                    Debug.Log(firstnum + "---" + lastnum);
                    formulaStr = formulaStr.Replace(firstnum + "-" + lastnum, (firstnum - lastnum).ToString());
                    Debug.Log(formulaStr);
                }
            }
        }
    }


    public void Except()
    {
        foreach (Match match in Regex.Matches(formulaStr, previousStr))
        {
            string s = match.Value;
            foreach (Match match1 in Regex.Matches(s, num))
            {
                firstnum = int.Parse(match1.Value);
            }
        }

        foreach (Match match in Regex.Matches(formulaStr, lastStr))
        {
            string s = match.Value;
            foreach (Match match1 in Regex.Matches(s, num))
            {
                lastnum = int.Parse(match1.Value);
            }
        }
    }


    
    string[] oper = {"/", "*", "-", "+",};
    List<float> data = new List<float>();
    List<string> operation = new List<string>();
    public void Test()
    {
        formulaStr = inputField.text;
        
        foreach (Match match in Regex.Matches(formulaStr, num))
        {
            data.Add(Convert.ToSingle(match.Value));
        }
        //拿出运算符
        foreach (char c in formulaStr)
        {
            for (int i=0;i<oper.Length;i++)
            {
                if (c.ToString() == oper[i])
                {
                    operation.Add(c.ToString());
                }
            }
        }


            //遍历运算符 优先级 /   *   -  +
            for (int i = 0; i < operation.Count; i++)
            {
                Debug.Log("operation.Count:"+operation.Count);
                if (IsOperation("/"))
                { 
                    Operation("/");
                }
                else if(IsOperation("*"))
                {
                    Operation("*");
                }
                if(IsOperation("-"))
                {
                    Operation("-");
                }
                if(IsOperation("+"))
                {
                    Operation("+");
                }
            }
            //设置条件
        
            foreach (float fl in data)
            {
                Debug.Log("data:"+fl);
            }
            /*foreach (string fl in operation)
            {
                Debug.Log("operation:"+fl);
            }*/

       

    }
    
    //判断数组中是否有运算符
    public bool IsOperation(string str)
    {
        for (int i = 0; i < operation.Count; i++)
        {
            if (operation[i] == str)
            {
                return true;
            }
        }
        return false;
    }

    public void Operation(string str)
    {
        int index = 0;
        for (int i = 0; i < oper.Length; i++)
        {
            if (oper[i] == str)
            {
                index = i;
            }
        }
        //遍历运算符 优先级 /   *   -  +
        for (int i = 0; i < operation.Count; i++)
        {
            if (operation[i] == str)
            {
                float num = 0;
                switch (index)
                {   
                    
                    case 0:
                        num = Convert.ToSingle(data[i]) / Convert.ToSingle(data[i + 1]);
                        operation.RemoveAt(i);
                        data[i] = num;
                        data.RemoveAt(i + 1);
                        break;
                    case 1:
                        num = Convert.ToSingle(data[i]) * Convert.ToSingle(data[i + 1]);
                        operation.RemoveAt(i);
                        data[i] = num;
                        data.RemoveAt(i + 1);
                        break;
                    case 2:
                        num = Convert.ToSingle(data[i]) - Convert.ToSingle(data[i + 1]);
                        operation.RemoveAt(i);
                        data[i] = num;
                        data.RemoveAt(i + 1);
                        break;
                    case 3:
                        num = Convert.ToSingle(data[i]) + Convert.ToSingle(data[i + 1]);
                        operation.RemoveAt(i);
                        data[i] = num;
                        data.RemoveAt(i + 1);
                        break;
                        
                }
                //Debug.Log("index:"+index+"num:"+num);
                
                
            }
        }
    }
    
    





}
