﻿using UnityEngine;
using System.Collections;

public class return2mainZJU : MonoBehaviour {
	
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnGUI(){
		if (GUILayout.Button ("Return", GUILayout.Height (50), GUILayout.Width (50))) {
			Application.LoadLevel ("main_ZJU");
		}
		
	}
}
