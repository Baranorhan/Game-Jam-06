using System;
using System.Collections;
using UnityEngine;

public class ScaleBehaviour : MonoBehaviour
{
    public GameObject Camera;
    public GameObject Parent;
    public int rightScaleTotalWeight;
    public int leftScaleTotalWeight;
    private int level = 0;
    public float speed = 20;

    public bool shouldRotate = true;
    // Start is called before the first frame update
    private void Start()
    {
        leftScaleTotalWeight = 0;
        rightScaleTotalWeight = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (!shouldRotate) return;
        if (rightScaleTotalWeight > leftScaleTotalWeight)
        {
            Rotate(-1);
        }else if (leftScaleTotalWeight > rightScaleTotalWeight)
        {
            Rotate(1);
        }
        else
        {   
            
            if (leftScaleTotalWeight > 0 && level % 2 == 0 )
            {
                RotateToZero();
                if(transform.rotation.z < 0.0001f && transform.rotation.z > -0.0001f)
                {
                    Debug.Log("done");
                    level += 1;
                    this.transform.rotation = Quaternion.Euler(Vector3.zero);
                     StartCoroutine(MoveFunction());

                }
            }
        }
    }

    private void RotateToZero()
    {
        if (transform.rotation.z <= 0.0001f)
        {
            transform.Rotate(Time.deltaTime  * speed * new Vector3(0, 0, 1));
        }
        else
        {
            transform.Rotate(Time.deltaTime  * speed * new Vector3(0, 0, -1));
     
        }
    }

    private void Rotate(float direction)
    {
        if (direction < 0 && transform.rotation.z <= -0.18) return;
        if (direction > 0 && transform.rotation.z >= 0.18) return;
        transform.Rotate(Time.deltaTime * direction * speed * new Vector3(0, 0, 1));
    }

    IEnumerator MoveFunction()
    {
        yield return new WaitForSeconds(3);

        float timeSinceStarted = 0f;
        while (true)
        {
            timeSinceStarted += Time.deltaTime;
            Vector3 newPosition = Camera.transform.position - transform.up / 5f;
            Camera.transform.position = Vector3.Lerp(Camera.transform.position, newPosition, timeSinceStarted);

            // If the object has arrived, stop the coroutine
            if (Camera.transform.position == newPosition)
            {
                yield return new WaitForSeconds(1);

                Parent.transform.position -= Parent.transform.position + transform.up * 1f;

                yield break;
            }

            // Otherwise, continue next frame
            yield return null;
        }
    }
  
}
