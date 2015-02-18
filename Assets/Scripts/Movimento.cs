using UnityEngine;
using System.Collections;

public class Movimento : MonoBehaviour {
	//public GameObject profi;
	private Animator animator;
	private bool colidindo;

	// Use this for initialization
	void Start () {
		animator = this.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {

		int direcao = animator.GetInteger ("direcao");

		int moonwalk = 1;

		if (colidindo) {

			if (Input.GetKey (KeyCode.RightArrow)) {
				direcao = 1;
			} else if (Input.GetKey (KeyCode.LeftArrow)) {
				direcao = -1;
			} else
				direcao = 0;

			if (Input.GetKey (KeyCode.LeftShift))
				moonwalk = -1;

			if (direcao == 0)
				animator.speed = 0;
			else
				animator.speed = 1;

			  if (Input.GetKeyDown (KeyCode.UpArrow))
				  this.rigidbody2D.AddForce (new Vector2 (0.0f, 200.0f));

			  this.animator.SetInteger ("direcao", direcao);
			  this.rigidbody2D.AddForce (new Vector2 (5.0f * direcao * moonwalk, 0.0f));
		}
	}

	void OnCollisionEnter2D(Collision2D coll) {
		colidindo = true;
	}

	void OnCollisionExit2D(Collision2D coll) {
	    colidindo = false;
	}

}