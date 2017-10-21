using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemyController : MonoBehaviour {

	public GameObject flyingEnemy;
	public float speed = 3f;
	public Transform current;
	public Transform[] locations;
	public int selection;

	private Rigidbody2D rb2d;
	private Transform _transform;




	// Use this for initialization
	void Start () {
		current = locations [selection];
		this.rb2d = gameObject.GetComponent<Rigidbody2D>();
		this._transform = gameObject.GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
		
		flyingEnemy.transform.position = Vector3.MoveTowards(flyingEnemy.transform.position, current.position, Time.deltaTime *speed);
		if (flyingEnemy.transform.position == current.position) 
		{
			selection++;
			if (selection == locations.Length)
			{
				selection = 0;
			}
			current = locations [selection];
		
	}
	}

}
