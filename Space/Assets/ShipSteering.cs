using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipSteering : MonoBehaviour
{

    // ship turn rate
    public float turnRate = 6.0f;

    // strength of leveling out
    public float levelDamping = 1.0f;

    void Update()
    {


        //new rotation
        //joystick direction * turn rate, clamp to 90% of half circle

        //get user input
        var steeringInput
          = InputManager.instance.steering.delta;

        //create rotation amount vector
        var rotation = new Vector2();

        rotation.y = steeringInput.x;
        rotation.x = steeringInput.y;

        // * turnRate to get steer amount
        rotation *= turnRate;

        // turn this into radians, * 90% of half circle
        rotation.x = Mathf.Clamp(
          rotation.x, -Mathf.PI * 0.9f, Mathf.PI * 0.9f);

        //turn radians into rotation quaternion
        var newOrientation = Quaternion.Euler(rotation);

        // combine turn with current orientation
        transform.rotation *= newOrientation;

        // minimize roll

        var levelAngles = transform.eulerAngles;
        levelAngles.z = 0.0f;
        var levelOrientation = Quaternion.Euler(levelAngles);

        transform.rotation = Quaternion.Slerp(
          transform.rotation, levelOrientation,
          levelDamping * Time.deltaTime);

    }
}
