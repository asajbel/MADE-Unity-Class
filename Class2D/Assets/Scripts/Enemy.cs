using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	protected bool dead = false;
	protected Vector3 spawn;
	public float deathHeight = -7f; 
	protected Animator anim;
	public Vector2 velocity; 
	public float deathSpeed = 150f; 
	public AudioSource hit;
	public int value = 100; 

	// Use this for initialization
	void Start () {
		spawn = transform.position;
		anim = GetComponent<Animator>(); 
		velocity = new Vector2(); 
	}

	void FixedUpdate() {
		if (dead) return; 
		MoveFixed (); 
	}
	
	// Update is called once per frame
	void Update () {
		anim.SetBool("Dead", dead); 
		if (dead && transform.position.y < deathHeight) {
			SetInactive ();
		}

		if (dead) return; 

		Move (); 
	}

	public virtual void Die () {
		dead = true; 
		transform.GetComponent<Collider2D>().enabled = false;
		rigidbody2D.AddForce(new Vector2(0, deathSpeed)); 
		hit.Stop();
		hit.Play(); 
	}

	public void SetInactive () {
		gameObject.SetActive(false); 
	}

	public virtual void Spawn () {
		gameObject.SetActive(true);
		dead = false;
		transform.GetComponent<Collider2D>().enabled = true; 
		transform.position = spawn;
	}

	public virtual void MoveFixed() {
		rigidbody2D.velocity = velocity; 
	}

	public virtual void Move() {
	
	}
}
