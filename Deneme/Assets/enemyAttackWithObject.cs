using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyAttackWithObject : MonoBehaviour
{
	public Transform attackPoint;
    public int attackDamage = 30;
	Collider2D playerhealth;
	void Update()
    {
        
    }
    void OnTriggerStay(Collider collision)
    {
        
		if (collision.gameObject.tag == "Player")
		{
			playerhealth.GetComponent<PlayerHealth>().TakeDamage(attackDamage);
            Debug.Log("HASARRR");
		}
    }
    


}
