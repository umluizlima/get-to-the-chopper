﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage_1 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (PlayerPrefs.GetInt ("prisoner") <= 0) {
			Application.LoadLevel ("Between 12");
		}		
	}
}
