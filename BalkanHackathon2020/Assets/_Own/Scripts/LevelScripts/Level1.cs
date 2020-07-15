using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1 : AbstractLevel
{
   public Transform[] turretHeads;
   public Transform playerTransform;
   private Vector3 targetPos;

   private void Update()
   {
      run = true;
      if (run)
      {
         targetPos = playerTransform.position;
         foreach (Transform t in turretHeads)
         {
            t.LookAt(targetPos);
         }
      }
   }
}
