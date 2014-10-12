using UnityEngine;
using System.Collections;

public class StartGame : MonoBehaviour {

	public string firstLevel;
	public Color color; 

	private Color original; 

	void Awake () {
		original = transform.GetComponent<GUIText>().color; 
	}

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown() {
		Application.LoadLevel(firstLevel); 
	}

	void OnMouseEnter() {
		transform.GetComponent<GUIText>().color = color;
	}

	void OnMouseExit() {
		transform.GetComponent<GUIText>().color = original; 
	}
}
