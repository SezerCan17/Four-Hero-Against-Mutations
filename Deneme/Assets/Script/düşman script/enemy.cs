using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class enemy : MonoBehaviour
{ 
    Animator animator;
    public float speed =5f;
    bool faceRight = false;
    public int turnDelay;
    private void Start()
    {
		
		StartCoroutine(SwitchDirection());
		
	}
    private void Update()
    {
		
		transform.Translate(Vector3.left*speed*Time.deltaTime);
		//animator.SetBool("move", true);
	}
    IEnumerator SwitchDirection()
    {
        yield return new WaitForSeconds(turnDelay);
		Switch();
		
	}
    private void Switch()
    {
		faceRight = !faceRight;
		Vector3 scaler = transform.localScale;
		scaler.x *= -1;
		transform.localScale = scaler;
        speed*= -1;
		
		StartCoroutine(SwitchDirection());
	}

}
