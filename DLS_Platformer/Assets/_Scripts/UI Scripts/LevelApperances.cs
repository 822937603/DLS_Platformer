﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelApperances : MonoBehaviour {

	public GameObject canvas;
	public GameObject lv2Text;
	public GameObject lv2Button;
	public GameObject lv2Location;

	void Awake () 
	{

	}

	void Start()
	{
		PlayerPrefs.SetInt ("LvDone", 0);
	}

	public void Lv2()
	{
		int Lv1Done = PlayerPrefs.GetInt("Lv1Done");
		if (Lv1Done == 1)
		{
			GameObject Lv2Text = Instantiate (lv2Text) as GameObject;
			canvas.transform.position = new Vector2 (85f, -3f);
			Lv2Text.transform.SetParent (canvas.transform);


			GameObject Lv2Button = Instantiate (lv2Button) as GameObject;
			canvas.transform.position = new Vector2 (85f, -23f);
			Lv2Button.transform.SetParent (canvas.transform);

			Instantiate (lv2Location);
		}
	}
}
