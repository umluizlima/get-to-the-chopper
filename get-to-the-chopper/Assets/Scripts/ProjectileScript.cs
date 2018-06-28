using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour {

	public int velocity;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {		
		transform.Translate (Vector2.left * velocity * Time.deltaTime);
	}

	void OnTriggerEnter2D(Collider2D other) {
		Debug.Log (other.name);
		if (other.gameObject.tag == "Player") {
			int healthPoints = PlayerPrefs.GetInt ("hp", 0) - 1;
			PlayerPrefs.SetInt ("hp", healthPoints);
		}
		Destroy (gameObject);
	}
}
