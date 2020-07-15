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

   private void OnCompileEnd(List<VirtualFunction> virtualFunctions)
   {
      run = true;
      for (int i = 0; i < virtualFunctions.Count; i++)
      {
         if (virtualFunctions[i].name == "AddForceToPlayer")
         {
            playersRb.AddForce(playersRb.transform.forward * virtualFunctions[i].values[0]);
         }
         else if (virtualFunctions[i].name == "SetTurretAim")
         {
            int index = (int)(virtualFunctions[i].values[0]);
            if (index > 1) continue;

            turrets[i].followTarget = false;
            turrets[i].targetPos = new Vector3(virtualFunctions[i].values[1],virtualFunctions[i].values[2],virtualFunctions[i].values[3]);
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
