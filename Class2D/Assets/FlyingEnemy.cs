using UnityEngine;
using System.Collections;

public class FlyingEnemy : Enemy {
	
	// Update is called once per frame
	void Update () {
		anim.SetBool("Dead", dead); 
		if (dead && transform.position.y < deathHeight) {
			SetInactive (); 
		}
	}
}
