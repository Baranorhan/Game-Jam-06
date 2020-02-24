using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquationGenerator3 : MonoBehaviour
{
   public int minConstantValue;
   public int maxConstantValue;
   //cube -> triangle -> circle
   public List<int> GenerateEquationConstants()
   {
      var constants = new List<int>();
      
      constants.Add(Random.Range(minConstantValue, maxConstantValue));
      constants.Add(Random.Range(minConstantValue, maxConstantValue));
      constants.Add(Random.Range(minConstantValue, maxConstantValue));
        //cube -> triangle
      constants.Add(Random.Range(minConstantValue, maxConstantValue));
      constants.Add(Random.Range(minConstantValue, maxConstantValue));
      //triangle -> circle
      constants.Add(Random.Range(minConstantValue, maxConstantValue));
      constants.Add(Random.Range(minConstantValue, maxConstantValue));
      return constants;

   }

}
