﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetweenScript_45 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Jump")) {
			Application.LoadLevel ("Stage 5");
		}
	}
}
