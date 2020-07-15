using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1 : AbstractLevel
{
   public Turret[] turrets;
   public Transform playerTransform;
   public float turretReloadTime = 2f;
   
   private Vector3 targetPos;

   private float timeCounter = 0f;
   
   private void Update()
   {
      run = true;
      if (run)
      {
         timeCounter++;
         
         targetPos = playerTransform.position;
         for (int i = 0; i < turrets.Length; i++)
         {
            turrets[i].AimAt(targetPos);
            
         }
         
         if (timeCounter >= turretReloadTime)
         {
            for (int i = 0; i < turrets.Length; i++)
            {
               turrets[i].ShootAt(targetPos);
               timeCounter = 0;
            
            }
         }
         
      }
   }

   void ShootTurret(Transform turretHead,Transform turretAim,Vector3 targetPos)
   {
      
   }
}
