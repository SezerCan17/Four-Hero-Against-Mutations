using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class bee : MonoBehaviour
{
	
	public float speed = 5f;
	public float turnDelay;
	private void Start()
	{

		StartCoroutine(SwitchDirection());

	}
	private void Update()
	{

		transform.Translate(Vector3.up * speed * Time.deltaTime);
		
	}
	IEnumerator SwitchDirection()
	{
		yield return new WaitForSeconds(turnDelay);
		Switch();

	}
	private void Switch()
	{
		
		Vector3 scaler = transform.localScale;
		
		transform.localScale = scaler;
		speed *= -1;

		StartCoroutine(SwitchDirection());
	}

}
