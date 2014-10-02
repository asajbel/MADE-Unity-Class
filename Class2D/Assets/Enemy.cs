using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public string DeathAnimation;
	protected bool dead = false;
	protected Vector3 spawn;
	protected float deathHeight = -50f; 
	protected Animator anim; 

	// Use this for initialization
	void Start () {
		spawn = transform.position;
		anim = GetComponent<Animator>(); 
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public virtual void Die () {
		dead = true; 
		rigidbody2D.gravityScale = 1; 
		transform.GetComponent<Collider2D>().enabled = false; 
	}

	public void SetInactive () {
		gameObject.SetActive(false); 
	}

	public virtual void Spawn () {
		gameObject.SetActive(true);
		dead = false;
		transform.position = spawn;
	}
}
