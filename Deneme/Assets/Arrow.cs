using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    Rigidbody2D rb2D;
    public float ArrowSpeed;
    public float endTime;
    public GameObject arrowImpact;
    Bow bow;
   

    void Awake()
    {
        rb2D= GetComponent<Rigidbody2D>();
        rb2D.velocity = transform.right * ArrowSpeed;
        //Destroy(gameObject,endTime);
        
        
    }
   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy"))
        {
            
           
        }
        GameObject sil= Instantiate(arrowImpact,transform.position, transform.rotation);
        Destroy(sil,0.333f);
    }  



}
