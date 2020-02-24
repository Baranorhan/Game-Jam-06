using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeComponent : MonoBehaviour
{
    public Rigidbody hook;

    public GameObject linkPrefab;

    public Weight weight;
    
    public int linkCount = 10;
    // Start is called before the first frame update
    void Start()
    {
        GenerateRope();
    }

    private void GenerateRope()
    {
        Rigidbody previousRb = hook;
        for (int i = 0; i < linkCount; i++)
        {
            var newLink = Instantiate(linkPrefab, transform);
            var joint = newLink.GetComponent<ConfigurableJoint>();
            joint.connectedBody = previousRb;
            if (i < linkCount - 1)
            {
                previousRb = newLink.GetComponent<Rigidbody>();
            }
            else
            {
                newLink.GetComponent<LinkBehaviour>().AddWeight(weight);
                weight.ConnectRopeEnd(newLink.GetComponent<Rigidbody>());
            }
        }
    }

}
