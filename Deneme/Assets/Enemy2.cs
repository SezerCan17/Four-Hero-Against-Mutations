using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Enemy2 : MonoBehaviour
{
	public Animator animator;
	public float speed = 5f;
	public bool faceRight;
	public Transform enemyGFX;
	public Rigidbody2D rb;
	public void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		faceRight = false;
	}

	public void Update()
	{

		transform.Translate(Vector3.right * speed * Time.deltaTime);
		if (speed>0)
		{
			enemyGFX.localScale = new Vector3(1f, 1f, 1f);
		}
		else if (speed<0)
		{
			enemyGFX.localScale = new Vector3(-1f, 1f, 1f);
		}
		animator.SetFloat("speed", Mathf.Abs(speed));

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
