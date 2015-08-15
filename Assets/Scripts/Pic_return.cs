using UnityEngine;
using System.Collections;

public class Pic_return : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnGUI(){
		if (GUILayout.Button ("Return", GUILayout.Height (50), GUILayout.Width (50))) {
			Application.LoadLevel ("神奈川");
		}
		if (Input.touchCount == 2 && Input.GetTouch (0).phase == TouchPhase.Moved) {
			if (Input.GetTouch (0).deltaPosition.x > 0 - Mathf.Epsilon) {
				Application.LoadLevel ("神奈川");
			}
		} 
	}
}
