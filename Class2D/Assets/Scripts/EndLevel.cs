using UnityEngine;
using System.Collections;

public class EndLevel : MonoBehaviour {

	private bool raised = false; 
	private Animator anim;

	void Awake () {
		anim = GetComponent<Animator>();
	}

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		anim.SetBool("Raised", raised);
	}

	void OnTriggerEnter2D (Collider2D col) {
		if (col.transform.tag == "Player") {
			raised = true;
		}
	}

	void NextLevel(string level) {
		Application.LoadLevel(level); 
	}
}
