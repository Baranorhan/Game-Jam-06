using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquationGenerator : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int Triangle = 1, Square = 2;
        int FirstItem;
        int SecondItem;
        do
        {
            FirstItem = Random.Range(1, 3);
            SecondItem = Random.Range(1, 3);
            
        } while ((FirstItem == Triangle && SecondItem == Triangle) || (FirstItem == Square && SecondItem == Square));
        if (FirstItem == Triangle && SecondItem == Square)
        {
            int FirstItemMultip = Random.Range(1, 4);
            int FirstItemValue = Random.Range(1, 11);
            int SecondItemMultip = Random.Range(1, 4);
            int SecondItemValue = Random.Range(1, 11);
            

        }

        else if (FirstItem == Square && SecondItem == Triangle)
        {
            int FirstItemMultip = Random.Range(1, 4);
            int FirstItemValue = Random.Range(1, 11);
            int SecondItemMultip = Random.Range(1, 4);
            int SecondItemValue = Random.Range(1, 11);

        }













    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
