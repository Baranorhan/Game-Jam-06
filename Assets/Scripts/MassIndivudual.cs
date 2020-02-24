using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MassIndivudual : MonoBehaviour
{
    // Start is called before the first frame update

    private Rigidbody  rb ;
    
    void Start()
    {
        Debug.Log(this.GetComponent<Rigidbody>().mass);
    }

    private void OnCollisionEnter(Collision col)
    {
        if (!col.transform.CompareTag("Scale")) return;
        Debug.Log("Hit the scale.");
    }
}
