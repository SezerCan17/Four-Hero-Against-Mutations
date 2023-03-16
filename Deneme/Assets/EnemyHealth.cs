using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
	private GameObject player;
	Animator animator;
    public int currentHealth;
    public int maxHealth=100;
    void Start()
    {
		player = GameObject.FindWithTag("Player");
		currentHealth = maxHealth;
    }
	
	public void TakeDamage(int damage)
	{

		currentHealth -= damage;
		if (currentHealth <= 0)
		{
			
		}
		
	}
	public void OnCollisionEnter2D(Collision2D collision)
	{
		
		if (collision.gameObject.CompareTag("PlayerAttackPoint"))
		{
			TakeDamage(20);
			animator.SetTrigger("Hurt");
		}

	}

}
