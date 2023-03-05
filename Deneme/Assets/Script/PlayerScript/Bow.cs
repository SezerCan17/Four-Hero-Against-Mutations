using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : MonoBehaviour
{
    public Transform Arrow_;
    public GameObject ArrowPrefabs;
    public Transform Arrow2_;
    public GameObject ArrowPrefabs2;
    public float Counter;
    public bool canAttack1;


    private void Start()
    {
        Counter = 0;
        canAttack1 = true;
    }

    private void Update()
    {
        counter();
        if(Input.GetKeyDown(KeyCode.X) && canAttack1)
        {
            Shoot();
            
        }
        if(Input.GetKeyDown(KeyCode.LeftAlt))
        {
            Shoot2();
        }

    }

    public void counter()
    {
        Counter -= Time.deltaTime;
        if (Counter <= 0)
        {
            canAttack1 = true;

        }

    }

    public void Shoot()
    {
        Instantiate(ArrowPrefabs, Arrow_.position, Arrow_.rotation);
        Counter = 1f;
        canAttack1= false;
        
    }
    public void Shoot2()
    {
        Instantiate(ArrowPrefabs2, Arrow2_.position, Arrow2_.rotation);
    }
    private IEnumerator Attack1_()
    {
       
        yield return new WaitForSecondsRealtime(0.6f);
    }
}
