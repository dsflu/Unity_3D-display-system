using UnityEngine;
using System.Collections;

public class nothing : MonoBehaviour {
	private float screen_width;
	private float screen_height;

	// Use this for initialization
	void Start () {
		screen_width = Screen.width;
		screen_height = Screen.height;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI() {
		if (GUI.Button (new Rect (0 , 0 , (200.0f/1280.0f)*screen_width , (50.0f/800.0f)*screen_height), "Return")) {
			Application.LoadLevel("ima_scan_start");
		}

		GUI.Label (new Rect(screen_width/2,screen_height/2,200,200),"暂无内容");
	}
}
