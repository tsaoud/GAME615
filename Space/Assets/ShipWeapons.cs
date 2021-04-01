using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipWeapons : MonoBehaviour
{

    public GameObject shotPrefab;

    //list of places where shots come from
    public Transform[] firePoints;

    private int firePointIndex;

    public void Fire()
    {
        if (firePoints.Length == 0)
            return;

        //which point to fire from
        var firePointTToUse = firePoints[firePointIndex];

        //create new shot
        Instantiate(shotPrefab,
            firePointTToUse.position,
            firePointTToUse.rotation);

        firePointIndex++;

        if (firePointIndex >= firePoints.Length)
            firePointIndex = 0;

       
    }
}
