using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSlingshot : MonoBehaviour
{
    Rigidbody2D myRB;
    LineRenderer myLine;
    public Transform pointer;
    public bool isDragging;
    private float power;
    public float mouseDist;

    // Start is called before the first frame update
    void Start()
    {
        power = 10f;
        myLine = gameObject.GetComponent<LineRenderer>();
        myLine.enabled = false;
        myRB = gameObject.GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            isDragging = true;

            mouseDist = Vector2.Distance(transform.position, pointer.position);

            myLine.enabled = true;
            myLine.SetPosition(0, transform.position);
            myLine.SetPosition(1, pointer.position);
        }

        if(Input.GetMouseButtonUp(0) && isDragging == true)
        {
            
            myLine.enabled = false;
            myRB.AddForce((transform.up * power) * mouseDist);
            isDragging = false;

        }
        
    }
}
