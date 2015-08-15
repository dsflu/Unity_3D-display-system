using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;  
using System;

public class Feinianci : MonoBehaviour {
	String Pic_file="近代费念慈隶书四言联.txt";
	String Article="";
	private bool showMsg = false;
	private bool showVideo = false;
	private float screen_width;
	private float screen_height;
	public GUIContent gc;
	public GUIContent bgpic;
	public GUIContent bgpic2;
	bool videoflag = false;
	// Use this for initialization
	void Start () {
		screen_width = Screen.width;
		screen_height = Screen.height;
		//读取文件
		ArrayList info = LoadFile(Application.dataPath+"/Resources/Files",Pic_file);
		
		foreach(string str in info)  
		{  
			Article+=str;
		} 
		Debug.Log (Article);
		gc.text = Article;
		//bgpic.image =
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.touchCount == 2 && Input.GetTouch (0).phase == TouchPhase.Moved) {
			if (Input.GetTouch (0).deltaPosition.x < 0 - Mathf.Epsilon)
			{
				Application.LoadLevel("近代费念慈隶书四言联介绍");
			}
		}
	}
	
	void OnGUI() 
	{
		GUI.Label (new Rect (200, 0.005f *screen_height,  screen_width, screen_height), bgpic);
		GUI.Label (new Rect (400, 0.005f *screen_height,  screen_width, screen_height), bgpic2);
		GUI.Label (new Rect ((1000.0f / 1280.0f) * screen_width, (65.0f / 800.0f) * screen_height,  screen_width, screen_height), "try move with two fingers");
		
		if (GUILayout.Button ("Return", GUILayout.Height (50), GUILayout.Width (50))) {
			Application.LoadLevel ("main_ZJU");
		}
		
		if (GUI.Button (new Rect ((1000.0f / 1280.0f) * screen_width, (10.0f / 800.0f) * screen_height, (200.0f / 1280.0f) * screen_width, (50.0f / 800.0f) * screen_height), "标题信息"))
			showMsg = !showMsg;
		if (showMsg) {
			//GUI.Label (new Rect (0, 150, (1000.0f / 1280.0f) * screen_width, screen_height), Article);
			GUI.Label (new Rect (10, 100, (1000.0f / 1280.0f) * screen_width, screen_height), gc);
		}
		if (GUI.Button (new Rect ((1000.0f / 1280.0f) * screen_width, (100.0f / 800.0f) * screen_height, (200.0f / 1280.0f) * screen_width, (50.0f / 800.0f) * screen_height), "视频信息")) {
			showVideo = !showVideo;
		}
		if (showVideo){
			//Debug.Log("dddddddd");
			if(!videoflag){
				GUI.Label(new Rect(10, 150, (1000.0f / 1280.0f) * screen_width, screen_height),"no video");
				//videoflag = false;
			}else {
				Application.LoadLevel("近代费念慈隶书四言联视频");
			}
		}
		
		
	}
	
	ArrayList LoadFile(string path,string name)   
	{   
		//使用流的形式读取
		StreamReader sr =null;
		try{
			sr = File.OpenText(path+"//"+ name);  
		}catch(Exception e)
		{
			//路径与名称未找到文件则直接返回空
			return null;
		}
		string line;
		ArrayList arrlist = new ArrayList();
		while ((line = sr.ReadLine()) != null)
		{
			//一行一行的读取
			//将每一行的内容存入数组链表容器中
			arrlist.Add(line);
		}
		//关闭流
		sr.Close(); 
		//销毁流
		sr.Dispose();
		//将数组链表容器返回
		return arrlist;
	}   
}
