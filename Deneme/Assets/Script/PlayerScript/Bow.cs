using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : MonoBehaviour
{
    public Transform Arrow_;
    public GameObject ArrowPrefabs;
    public Transform Arrow2_;
    public GameObject ArrowPrefabs2;


    
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.X))
        {
            Shoot();
        }
        if(Input.GetKeyDown(KeyCode.LeftAlt))
        {
            Shoot2();
        }

    }

    public void Shoot()
    {
        Instantiate(ArrowPrefabs, Arrow_.position, Arrow_.rotation);
    }
    public void Shoot2()
    {
        Instantiate(ArrowPrefabs2, Arrow2_.position, Arrow2_.rotation);
    }

}
