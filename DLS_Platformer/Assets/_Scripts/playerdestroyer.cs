﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerdestroyer : MonoBehaviour {

    public AudioClip deathSound;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	//reloads the scene upon collision with the player.
	void OnTriggerEnter2D(Collider2D otherCollider){

		if (otherCollider.gameObject.CompareTag("Player")){
            SoundManager.instance.PlaySingle(deathSound);
			Application.LoadLevel(Application.loadedLevel);
		}

	}
}
