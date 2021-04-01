using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    //forward shot speed
    public float speed = 100.0f;

    //time until shot removed
    public float life = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        //destroys game object after life amount seconds
        Destroy(gameObject, life);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
