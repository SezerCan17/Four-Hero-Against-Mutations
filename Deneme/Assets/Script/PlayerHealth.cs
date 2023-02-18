using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    Player Player;
    public int maxHealth = 100;
    public int health;
    void Start()
    {
        health = maxHealth;
    }

    
    public void TakeDamage(int damage)
    {
        
        health -= damage;
		Player.rb2D.AddForce(new Vector2(50, 100));
	}
}
