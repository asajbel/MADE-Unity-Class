using UnityEngine;
using System.Collections;

public class PassThru : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerStay2D (Collider2D col) {
		if (col.transform.tag == "Player") {
			if (!col.transform.GetComponent<Player>().IsGrounded()) 
				Physics2D.IgnoreLayerCollision(8, 9, true); 
		}
	}

	void OnTriggerExit2D (Collider2D col) {
		if (col.transform.tag == "Player") {
			Physics2D.IgnoreLayerCollision(8, 9, false); 
		}
	}
}
