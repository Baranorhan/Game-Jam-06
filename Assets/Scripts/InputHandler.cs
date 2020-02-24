using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    public float widthOver2;
    // Start is called before the first frame update
    private void Start()
    {
        widthOver2 = Screen.width / 2;
    }

    // Update is called once per frame
    private void Update()
    {
      /*  if (!Input.GetMouseButtonDown(0)) return;
        if (widthOver2 < Input.mousePosition.x)
        {
            GameManager.instance.RightSideTapped();
        }else if (widthOver2 > Input.mousePosition.x)
        {
            GameManager.instance.LeftSideTapped();
        }
*/
      
    }
}
