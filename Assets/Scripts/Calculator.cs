using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Calculator : MonoBehaviour
{

    [SerializeField] private Text resultText;

    private float num1 = 0.0f;
    private float num2 = 0.0f;
    private string operation;

    private float prevNum2 = 0.0f;
    private float prevNum1 = 0.0f;
    private float prevAns = 0.0f;
    private string prevOperation = "";

    

    private void Start()
    {
        TurnOff();
    }

   

    public void ClickNumber(string number)
    {
        
        if (resultText.text == Convert.ToString("0"))
        {
            resultText.text = number;
        }
        else if (prevOperation != "")
        {
            prevOperation = "";
            resultText.text = "";
            resultText.text += number;
        }
        else
        {
            resultText.text = resultText.text + number;

        }


        


    }

    public void ClickOperator(string op)
    {
        num1 = float.Parse(resultText.text);
        operation = op;
        resultText.text = "";
    }

    public void ClickDot()
    {
     
        resultText.text += ".";

    }

    public void ClickEqual()
    {
        
        float answer = 0.0f;

        try
        {
            num2 = float.Parse(resultText.text);
        }
        catch(FormatException f)
        {
            resultText.text = "Error";
            
        }


        Debug.Log(num1 + " " + operation + " " + num2);
        if (operation == "")
        {
            answer = num2;
        }
       
        if(prevOperation == operation && prevAns  == num2) 
        {
            num1 = prevAns;
            num2 = prevNum2;
            operation = prevOperation;
        }

       
        switch (operation)
        {
            case "+":
                answer = num1 + num2;
                break;
            case "-":
                answer = num1 - num2;
                break;
            case "*":
                answer = num1 * num2;
                break;
            case "/":
                answer = num1 / num2;
                break;
            default:
                break;
        }

        prevNum1 = answer;
        prevNum2 = num2;
        prevOperation = operation;
        prevAns = answer;

        resultText.text = answer.ToString();
        
        
    }





    public void ClickFunction(string function)
    {
        if(function == "ON")
        {
            TurnOn();
        }
        else if(function == "OFF")
        {
            TurnOff();
        }
        else
        {
            resultText.text = Convert.ToString("0");

            Clear();


        }
    }

    private void TurnOn()
    {
        resultText.text = "0";
        resultText.gameObject.SetActive(true);
    }

    private void TurnOff()
    {
        resultText.text = "0";
        resultText.gameObject.SetActive(false); 

    }

    
    private void Clear()
    {
        num1 = 0.0f;
        num2 = 0.0f;
        operation = "";
    }


    



}
