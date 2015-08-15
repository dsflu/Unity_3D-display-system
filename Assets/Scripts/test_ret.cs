using UnityEngine;
using System.Collections;

public class test_ret : MonoBehaviour {
	private float screen_width;
	private float screen_height;
	public GUIStyle TEMP = new GUIStyle();

	// Use this for initialization
	void Start () {
		screen_width = Screen.width;
		screen_height = Screen.height;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI(){
		if (GUILayout.Button ("Return", GUILayout.Height (50), GUILayout.Width (50))) {
			Application.LoadLevel ("Start_Scene");
		}
		GUI.Label (new Rect(screen_width/2.5f,screen_height/2.5f,200,200),"待建中。。。",TEMP);
	}
}
