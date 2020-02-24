using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Plane = UnityEngine.Plane;
using Vector3 = UnityEngine.Vector3;

public class Arrow : MonoBehaviour
{
    [Header("Arrow Firing")]
    public Camera cam;
    private Rigidbody rb;
    private bool readytofire = true;
    public GameObject Yay;
    public int speed;
    public float adjustarrow;
    public GameObject [] restHeart =  new GameObject[4];
   
    [Header("Aim Support")]
    public LineRenderer lr;
    public Transform arrowTip;
    public Transform touchedPosition;
    private int heartnum;
    public List<Vector3> positions;
    // Update is called once per frame
    void Start()
    {
        positions = new List<Vector3>();
        cam = Camera.main;
        rb = GetComponent<Rigidbody>();
        rb.centerOfMass = rb.transform.position - 6*transform.right;
        rb.isKinematic = true;
         heartnum = restHeart.Length ;

    }

void Update()
    {
        
        if (readytofire && Input.GetMouseButtonUp(0) && !GameManager.instance.gameOver)
        {
            var pos = GetWorldPositionOnPlane(Input.mousePosition, 0);
            Vector3 d = new Vector3(pos.x, pos.y, 0);

            if (adjustarrow * (d.x - transform.position.x) < 0)

            {
                restHeart[--heartnum].SetActive(false);
                lr.enabled = false;
                rb.isKinematic = false;
                if (d.x - transform.position.x > 0)
                    rb.AddForce(speed, speed * (d.y - transform.position.y) / Mathf.Abs(d.x - transform.position.x), 0);
                else
                    rb.AddForce(-speed, speed * (d.y - transform.position.y) / Mathf.Abs(d.x - transform.position.x), 0);
                readytofire = false;
                Debug.Log(d.y - transform.position.y);
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z + 180 * (d.y - transform.position.y) / 24);
            }
        }

        if (Input.GetMouseButton(0))
        {
            
            positions.Clear();
            arrowTip.localPosition = Vector3.zero;
            positions.Add(arrowTip.position);
            positions.Add(touchedPosition.position);
            lr.enabled = true;
            lr.SetPositions(positions.ToArray());
        }
    }


    private void OnTriggerEnter(Collider col)
    {
        if (heartnum == 0)
        {
            StartCoroutine(waitGameOver());
        } { 
        if (col.CompareTag("Link"))
        {
            Destroy(col.gameObject);
        }
        if (col.CompareTag("Wall"))
        {
            rb.isKinematic = true;
            readytofire = true;
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y + 180, 0);

          
            Yay.transform.position = new Vector3(transform.position.x + adjustarrow, transform.position.y, 0);
            transform.position = new Vector3(transform.position.x + adjustarrow, transform.position.y, 0);

            Yay.transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
            adjustarrow = -adjustarrow;
        }
        if (col.CompareTag("Enemy"))
        {
            GameManager.instance.GameOver();

        }
        }

    }
    public Vector3 GetWorldPositionOnPlane(Vector3 screenPosition, float z)
    {
        Ray ray = cam.ScreenPointToRay(screenPosition);
        Plane xy = new Plane(Vector3.forward, new Vector3(0, 0, z));
        float distance;
        xy.Raycast(ray, out distance);
        return ray.GetPoint(distance);
    }
    IEnumerator waitGameOver()
    {
        yield return new WaitForSeconds(3);

        GameManager.instance.GameOver();

        yield break;
        
    }
}
