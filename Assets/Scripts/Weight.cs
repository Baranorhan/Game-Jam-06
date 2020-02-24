
using System;
using System.Collections;
using UnityEngine;

public class Weight : MonoBehaviour
{
   public ConfigurableJoint joint;
   private Rigidbody rb;
   public float distanceFromRopeEnd;
   public int connectedBodies;


   public void ConnectRopeEnd(Rigidbody endRB)
   {
       connectedBodies++;
      rb = GetComponent<Rigidbody>();
      joint = gameObject.AddComponent<ConfigurableJoint>();
      joint.autoConfigureConnectedAnchor = false;
      joint.connectedBody = endRB;
      joint.anchor = Vector3.zero;
      joint.connectedAnchor = new Vector3(0, distanceFromRopeEnd);
      joint.xMotion = ConfigurableJointMotion.Limited;
      joint.yMotion = ConfigurableJointMotion.Limited;
      joint.zMotion = ConfigurableJointMotion.Locked;
      joint.angularXMotion = ConfigurableJointMotion.Limited;
      joint.angularYMotion = ConfigurableJointMotion.Limited;
      joint.angularZMotion = ConfigurableJointMotion.Locked;
      var jointLimit = joint.linearLimit;
      jointLimit.limit = distanceFromRopeEnd;
      joint.linearLimit = jointLimit;
     // rb.isKinematic = true;
   }

}
