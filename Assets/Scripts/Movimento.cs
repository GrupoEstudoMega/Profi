﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Movimento : MonoBehaviour {
	//public GameObject profi;
	private Animator animator;
	private bool colidindo;
	public GameObject display;
	private int score;
	public float velocidade;
	public float pulo;
	// Use this for initialization
	void Start () {
		animator = this.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		int direcao = animator.GetInteger ("direcao");

		int moonwalk = 1;

		if (Input.GetKey (KeyCode.RightArrow)) {
			direcao = 1;
		} else if (Input.GetKey (KeyCode.LeftArrow)) {
			direcao = -1;
		} else {
			direcao = 0;
		}
		
		if (Input.GetKey (KeyCode.LeftShift))
			moonwalk = -1;

		if (direcao == 0)
			animator.speed = 0;
		else
			animator.speed = 1;

		this.animator.SetInteger ("direcao", direcao);
		this.GetComponent<Rigidbody2D>().velocity = new Vector2 (velocidade * direcao * moonwalk, this.GetComponent<Rigidbody2D>().velocity.y);

		if (colidindo) {
			if (Input.GetKeyDown (KeyCode.UpArrow))
			   this.GetComponent<Rigidbody2D>().AddForce (new Vector2 (0.0f, pulo));
			//this.rigidbody2D.AddForce (new Vector2 (5.0f * direcao * moonwalk, 0.0f));
		}
	}

	void OnTriggerStay2D(Collider2D coll) {
		Debug.Log ("stay");
		colidindo = true;
	}

	void OnTriggerExit2D(Collider2D coll) {
	    colidindo = false;
	}

	void OnTriggerEnter2D(Collider2D col1) {
		if (col1.gameObject.tag == "coin") {
			Debug.Log (col1.gameObject.tag);
			Destroy(col1.gameObject);
			score++;
			display.GetComponent<Text>().text =  "R$ " + score.ToString();
		}

	}

}