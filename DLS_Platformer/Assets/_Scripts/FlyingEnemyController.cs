using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemyController : MonoBehaviour {

	public float speed = 1f;
	public float rSpeed = -3f;

	private Rigidbody2D rb2d;
	private Transform _transform;
	private Animator anim;

	// Use this for initialization
	void Start () {
		this.rb2d = gameObject.GetComponent<Rigidbody2D>();
		this._transform = gameObject.GetComponent<Transform>();
		this.anim = gameObject.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate(){
		this.anim.SetInteger("State", 1); //Moving state
		this.rb2d.velocity = new Vector2(0, this._transform.localScale.y) * this.speed;
	}

	void OnCollisionEnter2D(Collision2D collision){
		if (collision.gameObject.CompareTag("airbox")) {
			speed = rSpeed;
		}
		if (collision.gameObject.CompareTag("airbox2")) {
			rSpeed = speed;
		}

	}

}
