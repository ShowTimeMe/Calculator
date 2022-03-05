using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;

public class Calculator : MonoBehaviour
{

    public InputField inputField;
    public Text text;
    public Button button;
    string formulaStr = "123+344/111/3";
    // Start is called before the first frame update

    private void Awake()
    {
        text.text = "";
        button.onClick.AddListener(String);
    }
    public void Btn()
    {
        DataTable dt = new DataTable();
        //dt.Columns.Add("age", typeof(int));
        //dt.Columns.Add("name", typeof(string));
        //dt.Rows.Add(20, "张三");
        //dt.Rows.Add(22, "李四");
        //dt.Rows.Add(22, "王五");
        //Console.WriteLine("最大age值:" + dt.Compute("Max(age)", null));
        //Console.WriteLine("合计age值:" + dt.Compute("Sum(age)", null));
        //Console.WriteLine("age=22的合计值:" + dt.Compute("Sum(age)", "age=22"));
        //Console.WriteLine();
        //计算自定义公式
        //Console.WriteLine("请输入要计算的公式");
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
        //string str = "123/456";
        //string s1 = Regex.Matches(str, @"(\d+)/").ToString();
        //Debug.Log(Regex.Matches(str, @"(\d+)"));
        //text.text = Regex.Matches(str, @"(\d+)").ToString();
        //string str = inputField.text;
        //string[] str1= str.Split(new char[2] { '/', '*' });
        //foreach(string s in str1)
        //{
        //    Debug.Log(s);
        //}


        //string input = "123/456";
        //string previous = @"(\d+)/";
        //string last = @"/(\d+)";

        //foreach (Match match in Regex.Matches(input, previous))
        //    //Console.WriteLine(match.Value);
        //    Debug.Log(match.Value);
        //Debug.Log(Except());

        foreach (char c in formulaStr)
        {
            //Debug.Log(c.ToString());
            if (c.ToString() == "/")
            {
                Except();
            }
        }
    }


    public void Except()
    {
        string previous = @"(\d+)/";
        string last = @"/(\d+)";
        string num = @"\d+";

        float one = 0;
        float two = 0;

        foreach (Match match in Regex.Matches(formulaStr, previous))
        {
            string s = match.Value;
            foreach (Match match1 in Regex.Matches(s, num))
            {
                one = int.Parse(match1.Value);
            }
        }
        //Console.WriteLine(match.Value);
        //Debug.Log(match.Value);

        foreach (Match match in Regex.Matches(formulaStr, last))
        {
            string s = match.Value;
            foreach (Match match1 in Regex.Matches(s, num))
            {
                two = int.Parse(match1.Value);
            }
        }
        Debug.Log(one + "---" + two);
        formulaStr= formulaStr.Replace(one+"/"+two, (one / two).ToString());
        Debug.Log(formulaStr);
    }
}
