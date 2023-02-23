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

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.P)) 
        {
            TakeDamage(20);
        }
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
}
