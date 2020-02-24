using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorSetter : MonoBehaviour
{
    public MeshRenderer meshRenderer;
    // Start is called before the first frame update
    private void Start()
    {
        if(transform.CompareTag("Square") || transform.name == "SquareHolder"){
            meshRenderer.material.SetColor("_BaseColor", GameManager.instance.colors.colors[0]);
            meshRenderer.material.SetColor("_SpecColor", GameManager.instance.colors.colors[0]);
        
        }else if(transform.CompareTag("Triangle") || transform.name == "TriangleHolder"){
            meshRenderer.material.SetColor("_BaseColor", GameManager.instance.colors.colors[1]);
            meshRenderer.material.SetColor("_SpecColor", GameManager.instance.colors.colors[1]);
        
        }else if(transform.CompareTag("Circle") || transform.name == "CircleHolder"){
            meshRenderer.material.SetColor("_BaseColor", GameManager.instance.colors.colors[2]);
            meshRenderer.material.SetColor("_SpecColor", GameManager.instance.colors.colors[2]);
        
        }
    }

}
