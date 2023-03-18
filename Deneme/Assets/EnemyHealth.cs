using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
	private GameObject player;
	Animator animator;
    public int currentHealth;
    public int maxHealth=100;
	public bool isHurting = false;
    void Start()
    {
		player = GameObject.FindWithTag("Player");
		currentHealth = maxHealth;
    }
	
	public void TakeDamage(int damage)
	{

		currentHealth -= damage;
		isHurting = true ;
		if (currentHealth <= 0)
		{
			animator.SetTrigger("Death");
		}
		
	}
	private void OnTriggerEnter2D(Collider2D collision)
	{
		
		if (collision.gameObject.CompareTag("PlayerAttackPoint"))
		{
			TakeDamage(20);
			
		}
		
	}

}
