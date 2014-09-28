using UnityEngine;
using System.Collections;

public class HeadStomp : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D (Collider2D col) {
		if (col.transform.tag == "Enemy") {
			GetComponentInParent<Player>().Bounce(); 
			Destroy(col.gameObject); 
		}
	}
}
