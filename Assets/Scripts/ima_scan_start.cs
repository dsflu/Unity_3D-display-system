using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ima_scan_start : MonoBehaviour {
	public Texture bg;
	public Texture custom;
	public Texture yue;
	public Texture other;
	public static Vector2 NativeResolution = new Vector2(1280,800);
	private static float _guiScaleFactor = -1.0f;
	private static Vector3 _offset = Vector3.zero;
	private bool _didResizeUI;
	private float screen_width;
	private float screen_height;
	public GUIStyle button = new GUIStyle();
	public GUIStyle button_r = new GUIStyle();

	static List<Matrix4x4> stack = new List<Matrix4x4>();

	public void BeginUIResizing(){
		Vector2 nativeSize = NativeResolution;
		_didResizeUI = true;
		
		stack.Add (GUI.matrix);
		Matrix4x4 m = new Matrix4x4 ();
		float w = Screen.width;
		float h = Screen.height;
		float aspect = w / h;
		
		if (aspect < (nativeSize.x / nativeSize.y)) {
			//screen is taller
			_guiScaleFactor = (Screen.width / nativeSize.x);
			_offset.y = (Screen.height - (nativeSize.y * _guiScaleFactor)) * 0.5f;
		} 
		else {
			//screen is wider
			_guiScaleFactor = (Screen.height/nativeSize.y);
			_offset.x = (Screen.width-(nativeSize.x*_guiScaleFactor))*0.5f;
		}
		
		m.SetTRS (_offset,Quaternion.identity,Vector3.one*_guiScaleFactor);
		GUI.matrix *= m;
		
	}
	
	public void EndUIResizing(){
		GUI.matrix = stack[stack.Count - 1];
		stack.RemoveAt (stack.Count - 1);
		_didResizeUI = false;
	}
	// Use this for initialization
	void Start () {
		screen_width = Screen.width;
		screen_height = Screen.height;

		//button = new GUIStyle();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI() 
	{
		GUI.DrawTexture (new Rect(0,0,screen_width,screen_height),bg);

		GUI.Label (new Rect (screen_width / 2.5f, screen_height / 4, 100, 100), "分类",button);

		
		BeginUIResizing ();
		GUI.DrawTexture (new Rect (100 - _offset.x / _guiScaleFactor, 300 + _offset.y / _guiScaleFactor, 300, 300),yue);
		if (GUI.Button (new Rect (100 - _offset.x / _guiScaleFactor, 300 + _offset.y / _guiScaleFactor, 300, 300), "越地长歌",button)) {
			Application.LoadLevel("ima_scan_yue");
		}
		GUI.DrawTexture (new Rect (500 - _offset.x / _guiScaleFactor, 300 + _offset.y / _guiScaleFactor, 300, 300),custom);
		if (GUI.Button (new Rect (500 - _offset.x / _guiScaleFactor, 300 + _offset.y / _guiScaleFactor, 300, 300), "民间风俗",button)) {
			Application.LoadLevel("ima_scan_cus");		
		}
		GUI.DrawTexture (new Rect (900 - _offset.x / _guiScaleFactor, 300 + _offset.y / _guiScaleFactor, 300, 300),other);
		if (GUI.Button (new Rect(900-_offset.x/_guiScaleFactor,300+_offset.y/_guiScaleFactor,300,300),"其他",button)){
			Application.LoadLevel("Nothing");
		}
		if (GUI.Button (new Rect (10,-100, (400.0f/1280.0f)*screen_width , (100.0f/800.0f)*screen_height), "Return",button_r)) {
			Application.LoadLevel("Start_Scene");
		}
		EndUIResizing ();
	}
}
