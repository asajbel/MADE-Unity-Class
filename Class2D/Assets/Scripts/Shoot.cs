using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour {

	public GameObject bullet;
	public Transform spawn;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Fire1")) {
			GameObject b = (GameObject)Instantiate(bullet,spawn.position, Quaternion.identity); 
			Bullet t = b.transform.GetComponent<Bullet>(); 
//			b.transform.GetComponent<Bullet>().SetSpeed(
//				b.transform.GetComponent<Bullet>().speed * transform.parent.transform.localScale.x 
//				+ new Vector2(transform.parent.rigidbody2D.velocity.x, 0) );
			Transform p = transform.parent.transform; 
			Vector2 s = new Vector2(t.speed.x * p.localScale.x + p.rigidbody2D.velocity.x, 0);
			t.SetSpeed(s); 
		}
	}
}
