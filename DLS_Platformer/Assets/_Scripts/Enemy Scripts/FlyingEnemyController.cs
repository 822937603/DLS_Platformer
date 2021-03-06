using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemyController : MonoBehaviour {

    // ** Public Variables **

    public GameObject flyingEnemy;
	public float speed = 3f;
	public Transform current;
	public Transform[] locations;
	public int selection;

    // ** Private Variables **



	// Use this for initialization
	void Start () {

        // ** Get components **

        current = locations [selection];
	}
	
	// Update is called once per frame
	void Update () {

        // ** Flying enemy movement **

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
