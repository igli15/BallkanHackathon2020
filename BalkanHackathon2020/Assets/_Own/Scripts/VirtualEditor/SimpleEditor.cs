using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SimpleEditor : MonoBehaviour
{
    // Start is called before the first frame update

    public TMP_InputField inputField;
    public TMP_Text highlightedText;
    public SyntaxTheme syntaxTheme;
    public Compiler compiler;

    public static Action<List<VirtualFunction>> OnCompileEnd;
    public static Action<Compiler> OnCompileBegin;
    private bool leftControl = false;
    
    void Awake()
    {
        compiler = new Compiler(inputField.text);
    }

    public void ResetEditor()
    {
        inputField.text = "";
        highlightedText.text = "";
        leftControl = false;
    }
    
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftControl))
            leftControl = true;
        if(Input.GetKeyUp(KeyCode.LeftControl))
            leftControl = false;

        
        highlightedText.text = SyntaxHighlighter.HighlightCode(inputField.text,syntaxTheme);

        if (leftControl && Input.GetKeyDown(KeyCode.C))
        {
            compiler.PreprocessCode(inputField.text);
            
            if (OnCompileBegin != null) OnCompileBegin(compiler);
            List<VirtualFunction> list = compiler.Run();
            if (OnCompileEnd != null) OnCompileEnd(list);

        }
    }
}