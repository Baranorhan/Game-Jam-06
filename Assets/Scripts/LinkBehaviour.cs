using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinkBehaviour : MonoBehaviour
{
    private ConfigurableJoint cj;
    public List<Weight> weights;
    public GameObject linkCutParticle;
    void Start()
    {
        cj = GetComponent<ConfigurableJoint>();
    }

    public void AddWeight(Weight w)
    {
        if (weights == null)
        {
            weights = new List<Weight>();
        }
        weights.Add(w);
    }

    // Update is called once per frame
    void Update()
    {
        if (cj.connectedBody == null )
        {
            if (weights != null)
            {
                foreach (var w in weights)
                {
                    if(w.connectedBodies == 1){
                        Destroy(w.joint);}
                    else
                    {
                        w.connectedBodies--;
                    }
                    Debug.Log("Disabled variable!");
                }
            }

            Instantiate(linkCutParticle, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

}
