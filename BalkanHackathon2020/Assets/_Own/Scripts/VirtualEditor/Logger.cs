using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Logger : MonoBehaviour
{
    public TMP_InputField loggerInputField;

    private int lineCount = 0;
    private bool leftControl = false;
    private void OnEnable()
    {
        Compiler.OnPrint += UpdateLogger;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftControl))
            leftControl = true;
        if(Input.GetKeyUp(KeyCode.LeftControl))
            leftControl = false;

        if (leftControl && Input.GetKeyDown(KeyCode.L))
        {
            ClearLogger();
        }
    }

    void OnDisable()
    {
        Compiler.OnPrint -= UpdateLogger;
    }

    public void ClearLogger()
    {
        lineCount = 0;
        leftControl = false;
        loggerInputField.text = "CONSOLE: " + "\n";
    }
    
    void UpdateLogger(string printMsg)
    {
        loggerInputField.text +=  "\n"+ lineCount + " : " + printMsg;
        lineCount++;
    }
}
