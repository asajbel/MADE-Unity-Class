using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {
	private Transform player;
	
	void Awake () {
		player = GameObject.FindGameObjectWithTag("Player").transform;
	}
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		// By default the target x and y coordinates of the camera are it's current x and y coordinates.
		float targetX = player.position.x;
		//		float targetY = player.position.y;
		
		// Set the camera's position to the target position with the same z component.
		transform.position = new Vector3(targetX, transform.position.y, transform.position.z);
	}
}
