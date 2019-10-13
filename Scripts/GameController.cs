using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{


    private GameObject Selected;

    private LayerMask ForeGroundLayerMask;

    void Start()
    {
        Selected = null;

        ForeGroundLayerMask = LayerMask.GetMask("foreground");
    }

    
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
          
            Selected = ClickSelect();


           
            if (Selected!=null)
            {
              
                if (Selected.tag == "object")
                {
                    Destroy(Selected.gameObject);

                    Selected = null;
                }

            }
            

        }
    }


    private GameObject ClickSelect()
    {
        Vector2 rayPos = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        RaycastHit2D hit = Physics2D.Raycast(rayPos, Vector2.zero, Mathf.Infinity, ForeGroundLayerMask);



        if (hit)
        {
            print("clicked on obje");

            if (hit.transform.gameObject.tag == "object")
            {

                
                return hit.transform.gameObject;

            }
            

        }
        return null;
    }
}
