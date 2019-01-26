using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float FollowSpeed = 2f;
    public Transform Target;
    private Camera myCamera;

    private void Start()
    {
        myCamera = gameObject.GetComponent<Camera>();
    }

    private void Update()
    {
        Vector3 newPosition = Target.position;
        newPosition.z = -10;
        transform.position = Vector3.Slerp(transform.position, newPosition, FollowSpeed * Time.deltaTime);

        //myCamera.orthographicSize = Vector2.Distance(transform.position, newPosition) * 15;
    }

}


