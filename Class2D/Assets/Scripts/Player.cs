using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float speed = 0.2f; 
	public float airSpeed = 2f;
	public float jumpTime = 1f;

	private float airTime = 0f;
	private bool dead = false; 
	private bool canJump = true; 
	private Vector3 spawn;
	private bool facingRight = true; 

	// Use this for initialization
	void Start () {
		airTime = 0f; 
		spawn = transform.position; 
	}
	
	// Update is called once per frame
	void Update () {
		if (!dead) {
			transform.Translate(speed * Input.GetAxis("Horizontal"),
		                   		0,
		                    	0); 

			if (Input.GetButton("Jump") && airTime < jumpTime && canJump) {
				airTime += Time.deltaTime; 
				transform.Translate(0, airSpeed , 0);
			}

			if (Input.GetButtonUp ("Jump")){
				canJump = false;
				airTime = 0f; 
			}
			if (Input.GetAxis("Horizontal") > 0 && !facingRight)
				Flip();
			else if (Input.GetAxis("Horizontal") < 0 && facingRight)
				Flip();
		}
		else {
			transform.position = spawn; 
			dead = false;
		}
	}

	void OnCollisionStay2D (Collision2D col) {
		if (col.transform.tag == "Ground") {
			canJump = true; 
		}
	}

	void OnTriggerEnter2D (Collider2D col) {
		if (col.transform.tag == "DeathTrigger") {
			dead = true;
		}
	}

	void Flip ()
	{
		facingRight = !facingRight;
		
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
