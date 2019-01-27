using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalLine : MonoBehaviour
{
    public Transform target;
    LineRenderer myLine;
    // Start is called before the first frame update
    void Start()
    {
        myLine = gameObject.GetComponent<LineRenderer>();
        
    }

    // Update is called once per frame
    void Update()
    {
        myLine.SetPosition(0, transform.position);
        myLine.SetPosition(1, target.position);
        
    }
}
