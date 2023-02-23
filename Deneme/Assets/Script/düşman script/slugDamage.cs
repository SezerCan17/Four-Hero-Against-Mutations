using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slugDamage : MonoBehaviour
{
    public Animator myanims;
    public int damage;
    public PlayerHealth playerHealth;
    public Player player;

    private void OnCollisionEnter2D(Collision2D collision)
    {
		if (collision.gameObject.CompareTag("Enemy"))
		{
            Debug.Log("hasar");
            playerHealth.TakeDamage(damage);
			player.rb2D.AddForce(new Vector2(0, 50f));

			myanims.SetTrigger("Take_Hit");
        }
		
			
	

			
	
	}
}
