using UnityEngine;
using System.Collections;

public class HeadStomp : MonoBehaviour {

	private Score score; 

	// Use this for initialization
	void Start () {
		score = GameObject.Find("Score").GetComponent<Score>(); 
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D (Collider2D col) {
		if (col.transform.tag == "Enemy") {
			GetComponentInParent<Player>().Bounce(); 
			col.GetComponent<Enemy>().Die (); 
			score.score += col.GetComponent<Enemy>().value; 
		}
	}
}
