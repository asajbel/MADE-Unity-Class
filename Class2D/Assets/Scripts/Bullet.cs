using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	public Vector2 speed;
	public float distance = 10f;
	public Transform player;

	private float lifeTime; 
	private Score score;

	// Use this for initialization
	void Start () {
		lifeTime = 0f; 
		speed.x *= player.transform.localScale.x; 
		score = GameObject.Find("Score").GetComponent<Score>(); 
	}
	
	// Update is called once per frame
	void Update () {
		lifeTime += Time.deltaTime; 
		if (Mathf.Abs(lifeTime * speed.x) >= distance) {
			Destroy(gameObject);
		}
	}

	void FixedUpdate () {
		rigidbody2D.velocity = new Vector2(speed.x, rigidbody2D.velocity.y + speed.y); 
	}

	public void SetSpeed (Vector2 _speed) {
		speed = _speed; 
	}

	void OnCollisionEnter2D (Collision2D col) {
		if (col.transform.tag == "Enemy") {
			col.transform.GetComponent<Enemy>().Die(); 
			score.score += col.transform.GetComponent<Enemy>().value * 2; 
			Destroy(gameObject); 
		}
	}
}
