using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    Player Player;
    public Animator myanims;
    public int maxHealth = 100;
    public int health;
    void Start()
    {
        health = maxHealth;
    }

    
    public void TakeDamage(int damage)
    {
        
        health -= damage;
        if(health <= 0)
        {
            Debug.Log("Öldü");
            myanims.SetTrigger("Death");
        }
		Player.rb2D.AddForce(new Vector2(50, 100));
	}
}
