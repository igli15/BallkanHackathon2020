using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

   public LevelManager levelManager;
   private void OnTriggerEnter(Collider other)
   {
      if (other.CompareTag("Level0Trigger"))
      {
         levelManager.MoveToNextLevel();
      }
   }
   
   public void Die()
   {
      GetComponent<MeshRenderer>().enabled = false;
      GetComponent<Rigidbody>().velocity = Vector3.zero;
      Invoke("ResetLevel",1f);
   }

   private void ResetLevel()
   {
      levelManager.ResetCurrentLevel();
   }
}
