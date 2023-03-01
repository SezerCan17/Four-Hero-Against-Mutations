using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstarwithEnemy : MonoBehaviour
{
    public GameObject otherObject;
    public GameObject other2Object;
	public GameObject other3Object;
	public GameObject other4Object;
	public GameObject enterArea;
    
    void Start()
    {
        otherObject.GetComponent<EnemyAI>().enabled = false;
        other2Object.GetComponent<Enemy2>().enabled = true;
		other3Object.GetComponent<EnemyAI>().enabled = false;
		other4Object.GetComponent<Enemy2>().enabled = true;

	}

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Area")
        {
            otherObject.GetComponent<EnemyAI>().enabled = true;
            other2Object.GetComponent<Enemy2>().enabled = false;
			other3Object.GetComponent<EnemyAI>().enabled = true;
			other4Object.GetComponent<Enemy2>().enabled = false;
		}
	}
	public void OnTriggerExit2D(Collider2D collision)
	{
        if (collision.gameObject.tag == "Area")
        {
			
			otherObject.GetComponent<EnemyAI>().enabled = false;
		
			other2Object.GetComponent<Enemy2>().enabled = true;
			
			other3Object.GetComponent<EnemyAI>().enabled = false;

			other4Object.GetComponent<Enemy2>().enabled = true;

		}
	}
	
}
