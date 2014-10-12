using UnityEngine;
using System.Collections;

public class QuitGame : MonoBehaviour
{
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
		if (Input.GetButtonDown("Quit")) {
			Application.Quit(); 
		}
	}
	
	void OnMouseDown() {
		Application.Quit(); 
	}
	
	void OnMouseEnter() {
		transform.GetComponent<GUIText>().color = color;
	}
	
	void OnMouseExit() {
		transform.GetComponent<GUIText>().color = original; 
	}
}

