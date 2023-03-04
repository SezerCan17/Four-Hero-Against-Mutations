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
	public GameObject other5Object;
	public GameObject other6Object;
	public GameObject BOSS;
	public GameObject enterArea;
    
    void Start()
    {
        otherObject.GetComponent<EnemyAI>().enabled = false;
        other2Object.GetComponent<Enemy2>().enabled = true;
		other3Object.GetComponent<EnemyAI>().enabled = false;
		other4Object.GetComponent<Enemy2>().enabled = true;
		other5Object.GetComponent<EnemyAI>().enabled = false;
		other6Object.GetComponent<Enemy2>().enabled = true;


		BOSS.GetComponent<EnemyAI>().enabled = false;
	}

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Area")
        {
            otherObject.GetComponent<EnemyAI>().enabled = true;
            other2Object.GetComponent<Enemy2>().enabled = false;
			other3Object.GetComponent<EnemyAI>().enabled = true;
			other4Object.GetComponent<Enemy2>().enabled = false;
			other5Object.GetComponent<EnemyAI>().enabled = true;
			other6Object.GetComponent<Enemy2>().enabled = false;


			
		}
		if (collision.gameObject.tag == "BossArea")
		{
			BOSS.GetComponent<EnemyAI>().enabled = true;
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
			other5Object.GetComponent<EnemyAI>().enabled = false;
			other6Object.GetComponent<Enemy2>().enabled = true;



			
		}
		if (collision.gameObject.tag == "BossArea")
		{
			BOSS.GetComponent<EnemyAI>().enabled = false;
		}
	}

	
}
