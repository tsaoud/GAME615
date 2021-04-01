using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Obstacle : MonoBehaviour
{

    RobotMovement robotMovement;

    // Start is called before the first frame update
    private void Start()
    {
        robotMovement = GameObject.FindObjectOfType<RobotMovement>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Robot@Running")
        {
            //kill the player 
            robotMovement.Die();
        }
        
    }

    // Update is called once per frame
    private void Update()
    {
        
    }
}
