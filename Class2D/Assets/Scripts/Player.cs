using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float speed = 10f; 
	public float airSpeed = 5f;
	public float jumpSpeed = 100f;
	public float jumpTime = 0.035f;

	private float airTime = 0f;
	private bool dead = false; 
	private bool canJump = true; 
	private Vector3 spawn;
	private bool facingRight = true;
	private bool bounce = false;
	private Vector2 force;
	private Vector2 jumpForce;

	bool grounded = false;
	public Transform groundCheck;
	float groundRadius = 0.2f;
	public LayerMask whatIsGround; 

	Animator anim;

	// Use this for initialization
	void Start () {
		airTime = 0f; 
		spawn = transform.position; 
		force = new Vector2();
		jumpForce = new Vector2();
		anim = GetComponent<Animator>(); 
	}
	
	// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
	
	//FixedUpdate should be used instead of Update when dealing with Rigidbody.
	void FixedUpdate () {
		if (!dead) {

			grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
			anim.SetBool("Ground", grounded);
			
			force.y = rigidbody2D.velocity.y;
			if (grounded) {
				force.x = speed * Input.GetAxis("Horizontal");
			
				if (Input.GetAxis("Horizontal") > 0 && !facingRight)
					Flip();
				else if (Input.GetAxis("Horizontal") < 0 && facingRight)
					Flip();
			}
			else {
				force.x = airSpeed * Input.GetAxis("Horizontal");
			}

			anim.SetFloat("Speed", Mathf.Abs(force.x)); 
			rigidbody2D.velocity = force;  

		}

	}

	void Update() {
		if (!dead) {
			jumpForce.y = 0f;

			if ((Input.GetButton("Jump") || bounce) && airTime < jumpTime && canJump) {
				airTime += Time.deltaTime; 
				jumpForce.y += jumpSpeed;
				if (bounce && Input.GetButton("Jump")) {
					jumpForce.y += jumpSpeed;
				}
			}
			else if (airTime >= jumpTime) {
				bounce = false;
			}
			
			if (Input.GetButtonUp ("Jump")){
				canJump = false;
				airTime = 0f; 
			}
			rigidbody2D.AddForce(jumpForce); 
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

	public void Bounce ()
	{
		airTime = 0f;
		bounce = true; 
		canJump = true; 
	}

	public bool IsGrounded() {
		return grounded;
	}
}
