using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    Rigidbody2D rb2D;
    public float ArrowSpeed;
    public float endTime;
    public GameObject arrowImpact;
    public GameObject arrowKaravana;
    public GameObject arrowJumpAttack;
    
    void Awake()
    {
        rb2D= GetComponent<Rigidbody2D>();
        rb2D.velocity = transform.right * ArrowSpeed;
        Destroy(gameObject,endTime);
    }
   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            GameObject sil = Instantiate(arrowImpact, transform.position, transform.rotation);
            Destroy(sil, 0.667f);

        }
        if(collision.CompareTag("Ground"))
        {
            Destroy(gameObject);
            GameObject sil = Instantiate(arrowKaravana,transform.position, transform.rotation);
            Destroy(sil, 0.667f);
        }
    }
}
