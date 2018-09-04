﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public Rigidbody2D playerRb;
	public float speed = 5f;
	public float  jumpSpeed = 300;

	bool isGrounded = true;

	public Animator playeranim;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		playerRb.velocity = new Vector2(Input.GetAxis("Horizontal")* speed, playerRb.velocity.y);

		if(Input.GetAxis("Horizontal") == 0)
		{
			playeranim.SetBool("isWalking", false);
		}

		else if(Input.GetAxis("Horizontal") < 0)
		{
			playeranim.SetBool("isWalking", true);
			GetComponent<SpriteRenderer>().flipX=true;
		}

		else if(Input.GetAxis("Horizontal") > 0)
		{
			playeranim.SetBool("isWalking", true);
			GetComponent<SpriteRenderer>().flipX=false;
		}

		if (isGrounded)
		{

			if (Input.GetKeyDown(KeyCode.Space))
		{
			playerRb.AddForce(Vector2.up * jumpSpeed);
			isGrounded = false;

			playeranim.SetTrigger("Jump");
		}
		
		}
	}	

	private void OnCollisionEnter2D(Collision2D collision){

		if(collision.gameObject.CompareTag("Ground"))
		{
			isGrounded = true;
			
		}
	}
}	

