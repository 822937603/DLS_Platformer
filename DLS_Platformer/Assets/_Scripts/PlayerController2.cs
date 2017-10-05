﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2 : MonoBehaviour {
	
	public float speed = 50f;
	public float runSpeed = 100f;
	public float normalSpeed;
	public float jump = 200f;
	public bool isRunning = false;
	public bool grounded = true;

	private Rigidbody2D rgb;
	// Use this for initialization
	void Start () {
		this.rgb = gameObject.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate() {

		var x = Input.GetAxis ("Horizontal") * Time.deltaTime * speed;
		float y = 0;

		transform.Translate (x, 0, 0);

		if (Input.GetKey (KeyCode.A) && Input.GetKey (KeyCode.LeftShift) || Input.GetKey (KeyCode.D) && Input.GetKey (KeyCode.LeftShift)) {

			isRunning = true;
			speed = runSpeed;
		} else if (Input.GetKey (KeyCode.A) || Input.GetKey (KeyCode.D)) {
			isRunning = false;
		} else {
			isRunning = false;
			speed = normalSpeed;
		}

		if ((Input.GetKey(KeyCode.Space)) && grounded == true)
		    {
				grounded = false;
				y = this.jump;
			}

		this.rgb.AddForce(new Vector2(0, y));
		}

	void OnCollisionEnter2D(Collision2D coll)
	{

		if (coll.gameObject.tag == "Ground")
		{
			Debug.Log (grounded);
			grounded = true;
		} 
	}

	void OnCollisionExit2D(Collision2D coll)
	{

		if (coll.gameObject.tag == "Ground")
		{
			Debug.Log (grounded);
			grounded = false;
		} 
	}

	}
