using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour {

	public Text healthPointsText;
	public Text prisonerText;
	public float velocity;
	public Rigidbody2D body;
	public Animator animatorController;

	// Use this for initialization
	void Start () {
		PlayerPrefs.SetInt ("hp", 3);
		PlayerPrefs.SetInt ("prisoner", 5);
	}

	// Update is called once per frame
	void Update () {

		int healthPoints = PlayerPrefs.GetInt ("hp", 0);
		healthPointsText.text = "" + healthPoints;

		int prisonerCount = PlayerPrefs.GetInt ("prisoner", 0);
		prisonerText.text = "" + prisonerCount;

		if (animatorController.GetCurrentAnimatorStateInfo (0).IsName ("Dead")) {
			Application.LoadLevel ("Game Over");
			Destroy (gameObject);
		}

		if (PlayerPrefs.GetInt("hp") <= 0) {
			animatorController.SetBool ("Dead", true);
		}

		//Get inputs
		//bool jump = Input.GetButtonDown ("Jump");
		float move = Input.GetAxisRaw ("Horizontal");
		float elev = Input.GetAxisRaw ("Vertical");
		float speed = velocity * Time.deltaTime;
		//bool onGround = Physics2D.OverlapCircle (transformGroundCheck.position, 0.01f, layerMask);

		//Physics2D.OverlapCircle (transform.position, 2.0, 1);

		//if (jump && onGround) {
			//body.AddForce (new Vector2 (0, jumpForce));
			//Debug.Log ("Pulou!");
		//}

		if (move > 0) {
			animatorController.SetBool ("Right", true);
			transform.Translate (Vector2.left * speed);
			transform.eulerAngles = new Vector2 (0, 180);

		} else if (move < 0) {
			animatorController.SetBool ("Left", true);
			transform.Translate (Vector2.left * speed);
			transform.eulerAngles = new Vector2 (0, 0);

		} else {
			animatorController.SetBool ("Left", false);
			animatorController.SetBool ("Right", false);
		}

		if (elev > 0) {
			body.velocity = Vector2.up;
			transform.Translate (Vector2.up * speed);
		} else if (elev < 0) {
			body.velocity = Vector2.down;
			transform.Translate (Vector2.down * speed);
		}

		//animatorController.SetBool ("jump", !onGround);

	}
}
