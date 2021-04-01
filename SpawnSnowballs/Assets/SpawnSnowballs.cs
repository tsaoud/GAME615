using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSnowballs : MonoBehaviour
{
    public GameObject snowballPrefab;
    private GameObject cameraObj;

    // Start is called before the first frame update
    void Start()
    {
        cameraObj = GameObject.Find("Main Camera");
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    GameObject snowball = Instantiate(snowballPrefab, transform.position, transform.rotation);

        //    //compute the new direction and set it
        //    //this is just an example of "manually" computing a vector and setting it
        //    //in the common case of loooking at something, Unity has a built-in method
        //    //Vector3 vectorToTarget = cameraObj.transform.position - transform.position;
        //    //vectorToTarget = vectorToTarget.normalized;
        //    //snowball.transform.forward = vectorToTarget;
        //    snowball.transform.LookAt(cameraObj.transform);
        //}
    }

    public void SpawnSnowball()
    {
        GameObject snowball = Instantiate(snowballPrefab, transform.position, transform.rotation);

        snowball.transform.LookAt(cameraObj.transform);
    }
}

