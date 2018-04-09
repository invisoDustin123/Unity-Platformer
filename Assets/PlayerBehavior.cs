using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBehavior : MonoBehaviour {

	public float moveSpeed;
	public float accellerationSpeed;
	public float jumpPower;
	public int extraJumps = 1;
	public bool onGround;
	public GameObject cam;

	private bool isWalking = false;
	private int Jumps = 0;
	private bool isDead = false;
	private int timer = 0;

	private Rigidbody2D r;
	private SpriteRenderer sr;
	private AudioSource a;
	private Transform tf;
	private Animator an;

	// Use this for initialization
	void Start () {
		r = GetComponent<Rigidbody2D> ();
		sr = GetComponent<SpriteRenderer> ();
		a = GetComponent<AudioSource>();
		tf = GetComponent<Transform> ();
		an = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {

		if (isDead) {
			timer -= 1;
			if (timer < 1) { 
				SceneManager.LoadScene ("Menu", LoadSceneMode.Single);
			}
		}

		RaycastHit2D hit;
		hit = Physics2D.Raycast (tf.position, Vector3.down);
		if (hit.collider != null && (hit.collider.tag == "Ground" && hit.distance < 0.5f)) {
			onGround = true;
			Jumps = extraJumps;
		} else {
			onGround = false;
		}

		if (Input.GetKey (KeyCode.A)) {
			if (r.velocity.x > moveSpeed*-1) {
				r.velocity = new Vector2 (r.velocity.x-accellerationSpeed, r.velocity.y);
				sr.flipX = true;
			}
		}
		if (Input.GetKey (KeyCode.D)) {
			if (r.velocity.x < moveSpeed) {
				r.velocity = new Vector2 (r.velocity.x+accellerationSpeed, r.velocity.y);
				sr.flipX = false;
			}
		}

		if (r.velocity.x != 0) {
			isWalking = true;
		} else {
			isWalking = false;
		}

		an.SetBool ("isWalking", isWalking);

		if (Input.GetKeyDown (KeyCode.W)) {
			if (onGround) {
				a.Play ();
				r.velocity = new Vector2 (r.velocity.x, jumpPower);
			} else if (Jumps > 0) {
				a.Play ();
				r.velocity = new Vector2 (r.velocity.x, jumpPower);
				Jumps -= 1;
			}
		}

		cam.transform.position = new Vector3(tf.position.x, cam.transform.position.y, cam.transform.position.z);
	}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.tag == "win") {
			SceneManager.LoadScene ("Win", LoadSceneMode.Single);
		} else if (other.tag == "Kill" && !isDead) {
			other.GetComponent<AudioSource> ().Play ();
			isDead = true;
			timer = 60*5;
		}
	}
}
