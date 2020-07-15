using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Level0 : AbstractLevel
{
    public Rigidbody playersRb;


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

    public override void Reset()
    {
        playersRb.velocity = Vector3.zero;
        playersRb.transform.SetPositionAndRotation(playerSpawnTransform.position,playerSpawnTransform.rotation);
        editor.ResetEditor();
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
        compiler.AddInput("player.Speed", 80);
        compiler.AddOutputFunction("AddForceToPlayer");
    }
    
    void OnCompileEnd(List<VirtualFunction> virtualFunctions)
         {
             for (int i = 0; i < virtualFunctions.Count; i++)
             {
                 if (virtualFunctions[i].name == "AddForceToPlayer")
                 {
                     
                     float speed = virtualFunctions[i].values[0];
                     if (speed >= 150) speed = 150;
            
                     playersRb.AddForce(playersRb.transform.forward * speed);
                 }
             }
         }
}
