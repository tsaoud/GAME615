using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Get access to the Event interfaces
using UnityEngine.EventSystems;

// Get access to UI elements
using UnityEngine.UI;

// allows other objects to refer to a shared object
public class Singleton<T> : MonoBehaviour
  where T : MonoBehaviour
{

    // single instance of class.
    private static T _instance;


    public static T instance
    {
        get
        {
   
            if (_instance == null)
            {
                
                _instance = FindObjectOfType<T>();

               
                if (_instance == null)
                {
                    Debug.LogError("Can't find "
                      + typeof(T) + "!");
                }
            }

           
            return _instance;
        }
    }

}