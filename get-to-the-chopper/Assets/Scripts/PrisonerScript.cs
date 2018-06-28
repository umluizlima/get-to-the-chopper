using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrisonerScript : MonoBehaviour {

	//public Text prisonerText;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.gameObject.tag == "Player") {
			int prisonerCount = PlayerPrefs.GetInt ("prisoner", 0) - 1;
			PlayerPrefs.SetInt ("prisoner", prisonerCount);
	//		prisonerText.text = "" + prisonerCount;
			Destroy (this.gameObject);
		}
	}
}
