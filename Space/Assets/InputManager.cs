using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//public class InputManager : MonoBehaviour
//{
//    // joystick used to steer ship
//    public VirtualJoystick steering;
//}

public class InputManager : Singleton<InputManager>
{

    // joystick used to steer ship
    public VirtualJoystick steering;

}