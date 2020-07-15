using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1 : AbstractLevel
{
   public Transform[] turretHeads;
   public Transform[] aimTransforms;
   public LineRenderer[] turretAims;
   public Transform playerTransform;
   public float turretReloadTime = 2f;
   
   private Vector3 targetPos;
   
   private void Update()
   {
      run = true;
      if (run)
      {
         targetPos = playerTransform.position;
         for (int i = 0; i < 2; i++)
         {
            turretHeads[i].LookAt(targetPos);
            turretAims[i].SetPosition(0,aimTransforms[i].position);
            turretAims[i].SetPosition(1,targetPos);
         }
         
      }
   }
   
}
