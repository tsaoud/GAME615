using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothFollow : MonoBehaviour
{

    //target being followed
    public Transform target;

    //height of camera above target
    public float height = 5.0f;

    //distance to target
    public float distance = 10.0f;

    //how much to slow change in rotation & height
    public float rotationDamping;
    public float heightDamping;



    // Update is called once per frame
    void LateUpdate()
    {
        if (!target)
            return;

        //calculate current rotation angles
        var wantedRotationAngle = target.eulerAngles.y;
        var wantedHeight = target.position.y + height;

        //currently positioned and facing
        var currentRotationAngle = transform.eulerAngles.y;
        var currentHeight = transform.position.y;

        //damp the height
        currentHeight = Mathf.Lerp(currentHeight, wantedHeight, heightDamping * Time.deltaTime);

        //convert angle into a rotation
        var currentRotation = Quaternion.Euler(0, currentRotationAngle, 0);

        //set position of camerra on x-z plane to 'distance' meters behind target
        transform.position = target.position;
        transform.position -= currentRotation * Vector3.forward * distance;

        //set position of camera using new height
        transform.rotation = Quaternion.Lerp(transform.rotation, target.rotation, rotationDamping * Time.deltaTime);

    }
}
