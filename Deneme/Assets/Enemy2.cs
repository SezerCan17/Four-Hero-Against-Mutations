using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Enemy2 : MonoBehaviour
{
	EnemyAI EnemyAI;
	Animator animator;
	public float speed = 5f;
	public bool faceRight =true;
	private void Start()
	{

		faceRight = true;
	}

	private void Update()
	{
		transform.Translate(Vector3.right * speed * Time.deltaTime);
		if (EnemyAI.rb.velocity.x < 0)
		{
			transform.Translate(Vector3.left * speed * Time.deltaTime);
		}
		else if (EnemyAI.rb.velocity.x > 0)
		{
			transform.Translate(Vector3.right * speed * Time.deltaTime);
		}



	}
	public void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "secretwall")
		{
			Switch();
		}
	}
	private void Switch()
	{
		faceRight = !faceRight;
		Vector3 scaler = transform.localScale;
		scaler.x *= -1;
		transform.localScale = scaler;
		speed *= -1;

		
	}

}
