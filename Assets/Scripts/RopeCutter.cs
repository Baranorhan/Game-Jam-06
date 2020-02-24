using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeCutter : MonoBehaviour
{
    public Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            var pos = GetWorldPositionOnPlane(Input.mousePosition, 0);
            transform.position = new Vector3(pos.x, pos.y, 0);
        }
    }

    private void OnTriggerEnter(Collider col)
    {
   /*     if (col.CompareTag("Link"))
        {
            Destroy(col.gameObject);
        }*/
    }
    public Vector3 GetWorldPositionOnPlane(Vector3 screenPosition, float z) {
        Ray ray = cam.ScreenPointToRay(screenPosition);
        Plane xy = new Plane(Vector3.forward, new Vector3(0, 0, z));
        float distance;
        xy.Raycast(ray, out distance);
        return ray.GetPoint(distance);
    }

}
