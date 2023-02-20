using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : MonoBehaviour
{
    public Transform Arrow_;
    public GameObject ArrowPrefabs;
    
    private void FixedUpdate()
    {
        if(Input.GetKeyDown(KeyCode.X))
        {
            Shoot();
        }


    }

    public void Shoot()
    {
        Instantiate(ArrowPrefabs, Arrow_.position, Arrow_.rotation);
    }

}
