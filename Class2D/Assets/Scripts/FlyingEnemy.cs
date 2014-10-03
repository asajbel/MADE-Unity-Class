using UnityEngine;
using System.Collections;

public class FlyingEnemy : Enemy {

	public override void Die ()
	{
		base.Die ();
		rigidbody2D.gravityScale = 1; 
	}

	public override void Spawn ()
	{
		base.Spawn ();
		rigidbody2D.gravityScale = 0; 
	}
}
