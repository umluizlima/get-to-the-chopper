using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyScript : MonoBehaviour {

	//public Text healthPointsText;
	public Animator animatorController;
	private bool touched;
	public GameObject projectile, shooter;
	private float lastShootTime = 0;
	public float shotInterval;

	// Use this for initialization
	void Start () {
		touched = false;
		if (this.transform.rotation.y == 180) {
			this.projectile.transform.eulerAngles = new Vector2 (0, 180);
		} else {
			this.projectile.transform.eulerAngles = new Vector2 (0, 0);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (animatorController.GetCurrentAnimatorStateInfo(0).IsName("Dead")) {
			Destroy(this.gameObject);
		}

		if (lastShootTime + shotInterval < Time.time) {
			projectile.transform.position = shooter.transform.position;
			Instantiate (projectile);
			lastShootTime = Time.time;
		}
	}

	void OnTriggerEnter2D (Collider2D other) {
		if (touched == false && other.gameObject.tag == "Player") {
			touched = true;
			animatorController.SetBool ("Dead", true);
			int healthPoints = PlayerPrefs.GetInt ("hp", 0) - 1;
			PlayerPrefs.SetInt ("hp", healthPoints);
			//healthPointsText.text = "" + healthPoints;
		}
	}
}
