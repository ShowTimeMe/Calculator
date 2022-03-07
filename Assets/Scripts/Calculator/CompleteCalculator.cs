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


    private int firstnum = 0;
    private int lastnum = 0;

    private List<string> data=new List<string>();
    private List<string> oper=new List<string>();

    private void Start()
    {
        button.onClick.AddListener(Calculation);
    }

    public void Calculation()
    {
        formulaStr = inputField.text;
        foreach (Match match in Regex.Matches(formulaStr, selectNum))
        {
            data.Add(match.Value);
        }

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

        foreach (var v in data)
        {
            Debug.Log("data:"+v);
        }
        foreach (var v in oper)
        {
            Debug.Log("oper:"+v);
        }
    }
}
