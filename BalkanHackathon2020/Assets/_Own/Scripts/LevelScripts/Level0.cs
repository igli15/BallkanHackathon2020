using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Level0 : AbstractLevel
{
    public SimpleEditor editor;
    public Rigidbody playersRb;

    public TextMeshProUGUI helpTextMesh;
    
    
    // Start is called before the first frame update
    void Start()
    {
        helpTextMesh.text = "\n" + "<#F188AC>VARIABLES:</color> " + "\n" +
                            "-------------------------------" 
                            +"\n" + 
                            "player.speed" +
                            "\n" + "\n"+  "\n" + "\n" + 
                            "<#F188AC>FUNCTIONS:</color> " + 
                            "\n" +
                            "-------------------------------" +
                            "\n" +
                            "AddForceToPlayer(force)"+
                            "\n" + "\n"+  "\n" + "\n" +
                            "<#F188AC>GOAL:</color> " +
                            "\n"+
                            "-------------------------------" +
                            "\n" +
                    "Get the player to safety past the (blue) line" +  
                            "\n" + "\n"+  "\n" + "\n" + 
                            "<#F188AC>COMMANDS:</color> " + 
                            "\n" +
                            "-------------------------------" +
                            "\n"+
                            "CTRL + C: Run Code" + "\n" +
                            "CTRL + L: Clear Console" + "\n" +
                            "CTRL + R: Restart Level" + "\n"; 
    }

    public void Reset()
    {
        
    }

    
    private void OnEnable()
    {
        SimpleEditor.OnCompileEnd += OnCompileEnd;
        SimpleEditor.OnCompileBegin += OnCompileBegin;
    }

    private void OnDisable()
    {
        SimpleEditor.OnCompileEnd -= OnCompileEnd;
        SimpleEditor.OnCompileBegin -= OnCompileBegin;
    }

    void OnCompileBegin(Compiler compiler)
    {
        editor.compiler.AddInput("player.Speed", 80);
        editor.compiler.AddOutputFunction("AddForceToPlayer");
    }
    
    void OnCompileEnd(List<VirtualFunction> virtualFunctions)
         {
             for (int i = 0; i < virtualFunctions.Count; i++)
             {
                 if (virtualFunctions[i].name == "AddForceToPlayer")
                 {
                     Debug.Log("here");
                     playersRb.AddForce(playersRb.transform.forward * virtualFunctions[i].values[0]);
                 }
             }
         }
}
