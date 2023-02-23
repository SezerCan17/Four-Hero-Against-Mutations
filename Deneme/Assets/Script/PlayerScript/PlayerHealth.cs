using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerHealth : MonoBehaviour
{
    Player Player;
    public Animator myanims;
    public int maxHealth = 100;
    public int health;

    public HealthBar healthBar;
    void Start()
    {
        health = maxHealth;
        Player= GetComponent<Player>();
        healthBar.SetMaxHealth(maxHealth);
    }


    public void TakeDamage(int damage)
    {
        
        health -= damage;
        if(health <= 0)
        {
            Player.Death();
        }
		healthBar.SetHealth(health);
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            TakeDamage(20);
        }

    }

}
