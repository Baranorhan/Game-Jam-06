using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleWeightBehaviour : MonoBehaviour
{
   public ScaleBehaviour scaleBehaviour;
   public int side;
   private void OnTriggerEnter(Collider other)
   {
      var weight = 0;
      if (other.transform.CompareTag("Square"))
      {
         GameManager.instance.ItemDroppedIn();
         weight = GameManager.instance.massGiver.cubeMass;
      } 
      if (other.transform.CompareTag("Circle"))
      {
         GameManager.instance.ItemDroppedIn();
         weight = GameManager.instance.massGiver.circleMass;
      } 
      if (other.transform.CompareTag("Triangle"))
      {
         GameManager.instance.ItemDroppedIn();
         weight = GameManager.instance.massGiver.triangleMass;
      }
      if (side < 0)
      {
         scaleBehaviour.leftScaleTotalWeight += weight;
      }
      else
      {
         scaleBehaviour.rightScaleTotalWeight += weight;
      }
      
   }

   private void OnTriggerExit(Collider other)
   {
      var weight = 0;
      if (other.transform.CompareTag("Square"))
      {
         GameManager.instance.ItemDroppedOut();
         weight = GameManager.instance.massGiver.cubeMass;
      }
      if (other.transform.CompareTag("Circle"))
      {
         GameManager.instance.ItemDroppedOut();
         weight = GameManager.instance.massGiver.circleMass;
      } 
      if (other.transform.CompareTag("Triangle"))
      {
         GameManager.instance.ItemDroppedOut();
         weight = GameManager.instance.massGiver.triangleMass;
      }
      if (side < 0)
      {
         scaleBehaviour.leftScaleTotalWeight -= weight;
      }
      else
      {
         scaleBehaviour.rightScaleTotalWeight -= weight;
      }
   }
}
