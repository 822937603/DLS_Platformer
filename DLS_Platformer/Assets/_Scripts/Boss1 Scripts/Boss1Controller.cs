﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1Controller : MonoBehaviour {

    // ** Public variables **

    public GameObject boss;
	public GameObject negativeFire;
	public GameObject positiveFire;
	public GameObject laserFire;
	public GameObject environmentDamager;

	public float moveSpeed;
	public Transform current;
	public Transform newPoint;
	public Transform visionStart;
	public Transform visionEnd;
	public Transform Platform1FireEndPoint;
	public Transform FirePosition;
	public float delay = 1.0f;
	bool changeLocations = true;
	public int damagerHitNumber = 0;


	public bool singleFire = true;
	public bool negative = true;
	public bool positive = false;
	public bool phase2 = false;
	public bool phase3 = false;

	private bool iSeeYou = false;
	private float fire= 0.0f;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        // ** Boss movement **

        if (changeLocations == true)
		{
			boss.transform.position = Vector3.MoveTowards (boss.transform.position, newPoint.position, Time.deltaTime * moveSpeed);
		}
		if (boss.transform.position == newPoint.position) 
		{
			changeLocations = false;
		}
		if (changeLocations == false)
		{
			boss.transform.position = Vector3.MoveTowards (boss.transform.position, current.position, Time.deltaTime * moveSpeed);

		}
		if (boss.transform.position == current.position) 
		{
			changeLocations = true;
		}

		this.iSeeYou = Physics2D.Linecast(this.visionStart.position, this.visionEnd.position, 1 << LayerMask.NameToLayer("Player"));
		Debug.DrawLine(this.visionStart.position, this.visionEnd.position);

		if (iSeeYou == true) {

			if (singleFire == true && phase2 == true && Time.time > fire) {
				fire = Time.time + delay;
				Instantiate (laserFire, FirePosition.transform.position, FirePosition.rotation);
			}

			else if (negative == true && Time.time > fire) {
				fire = Time.time + delay;
				Instantiate (negativeFire, FirePosition.position, FirePosition.rotation);
				singleFire = false;
				negative = false;
				positive = true;
			} else if (positive == true && Time.time > fire) {
				fire = Time.time + delay;
				Instantiate (positiveFire, FirePosition.position, FirePosition.rotation);
				singleFire = false;
				positive = false;
				negative = true;
			}
		}
	}


	void OnTriggerEnter2D(Collider2D coll)
	{
		// ** Boss damage **

		if (coll.gameObject.tag == "EnvironmentDamager") {
			damagerHitNumber++;
//			phase2 = true;
//			if (phase2 == true && damagerHitNumber == 1) {
//				damagerHitNumber++;
//				Destroy (coll.gameObject);
//				moveSpeed = 10;
//		
//				GameObject.Find ("Player").GetComponent<PlayerController2> ().environDamager.SetActive (true);
//
//				GameObject.Find ("ButtonController").GetComponent<ButtonController> ().current.SetActive (true);
//				phase3 = true;
//			}
//			if (phase3 == true && damagerHitNumber == 2) {
//
//				Destroy (this.gameObject);
//			}

			switch (damagerHitNumber) {
			case 0:
			
				break;
			case 1:
				phase2 = true;
				Destroy (coll.gameObject);
				moveSpeed = 10;

				GameObject.Find ("Player").GetComponent<PlayerController2> ().environDamager.SetActive (true);

				GameObject.Find ("ButtonController").GetComponent<ButtonController> ().current.SetActive (true);
				damagerHitNumber++;
				break;
			case 2:
				//WHY DOES damagerHitNumber GO RIGHT TO 2???
				damagerHitNumber++;
				break;
			case 3:
				Destroy(this.gameObject);
				Destroy (coll.gameObject);
				break;
			}
		}
	}

	void OnTriggerExit2D(Collider2D coll)
	{
		singleFire = true;
	}

}
