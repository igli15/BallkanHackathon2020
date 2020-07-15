using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1 : AbstractLevel
{
   public Turret[] turrets;
   public Transform playerTransform;
   public float turretReloadTime = 2f;
   public Rigidbody playersRb;

   private float timeCounter = 0f;

   private void Start()
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
                          "\n" +
                          "SetTurretAim(turretIndex,x,y,z)" + 
                          "\n" + "\n"+  "\n" + "\n" +
                          "<#F188AC>GOAL:</color> " +
                          "\n"+
                          "-------------------------------" +
                          "\n" +
                          "Avoid getting shot by turrets and move the player past the blue line" +  
                          "\n" + "\n"+  "\n" + "\n" + 
                          "<#F188AC>COMMANDS:</color> " + 
                          "\n" +
                          "-------------------------------" +
                          "\n"+
                          "CTRL + C: Run Code" + "\n" +
                          "CTRL + L: Clear Console" + "\n" +
                          "CTRL + R: Restart Level" + "\n"; 
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
   
   public override void Reset()
   {
      playersRb.GetComponent<MeshRenderer>().enabled = true;
      playersRb.velocity = Vector3.zero;
      playersRb.transform.SetPositionAndRotation(playerSpawnTransform.position,playerSpawnTransform.rotation);

      foreach (var turret in turrets)
      {
         turret.Reset();
      }
      editor.ResetEditor();

      run = false;
   }

   private void OnCompileEnd(List<VirtualFunction> virtualFunctions)
   {
      run = true;
      for (int i = 0; i < virtualFunctions.Count; i++)
      {
         if (virtualFunctions[i].name == "AddForceToPlayer")
         {
            float speed = virtualFunctions[i].values[0];
            if (speed >= 150) speed = 150;
            
            playersRb.AddForce(playersRb.transform.forward * speed);
         }
         else if (virtualFunctions[i].name == "SetTurretAim")
         {
            int index = (int)(virtualFunctions[i].values[0]);
            if (index > 1) continue;
            
            turrets[index].followTarget = false;
            turrets[index].targetPos = new Vector3(virtualFunctions[i].values[1],virtualFunctions[i].values[2],virtualFunctions[i].values[3]);
         }
      }
   }

   private void OnCompileBegin(Compiler compiler)
   {
      compiler.AddInput("player.Speed", 80);
      compiler.AddOutputFunction("AddForceToPlayer");
      compiler.AddOutputFunction("SetTurretAim");
   }
   

   private void Update()
   {
      if (run)
      {
         timeCounter+= Time.deltaTime;
         
         for (int i = 0; i < turrets.Length; i++)
         {
            if (turrets[i].followTarget)
            {
               turrets[i].targetPos = playerTransform.position;
            }

            turrets[i].AimAtTarget();
         }
         
         if (timeCounter >= turretReloadTime)
         {
            for (int i = 0; i < turrets.Length; i++)
            {
               turrets[i].ShootAtTarget();
               timeCounter = 0;
            }
         }
         
      }
   }
}
