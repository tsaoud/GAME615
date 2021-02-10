using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropCube : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Rigidbody rb = gameObject.GetComponent<Rigidbody>();
            rb.useGravity = true;

            rb.AddForce(transform.forward * 1000.0f);
        }
    }
}
