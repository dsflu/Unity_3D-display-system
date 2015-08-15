using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;  
using System;

public class Feinianci_intro : MonoBehaviour {
	String Pic_file="近代费念慈隶书四言联_介绍.txt";
	String Article="";
	public GUIContent gc;
	public GUIStyle label;
	
	
	// Use this for initialization
	void Start () {
		
		ArrayList info = LoadFile(Application.dataPath+"/Resources/Files",Pic_file);
		
		foreach(string str in info)  
		{  
			Article+=str;
			Article+="\n";
		} 
		gc.text = Article;
		//label.
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Input.touchCount == 2 && Input.GetTouch (0).phase == TouchPhase.Moved) {
			if (Input.GetTouch (0).deltaPosition.x > 0 - Mathf.Epsilon) {
				Application.LoadLevel ("近代费念慈隶书四言联");
			}
			
		} 
	}
	
	void OnGUI() 
	{
		//GUI.Label (new Rect (Screen.width/8, Screen.height/8, (1000.0f / 1280.0f) * Screen.width, Screen.height), gc);
		
		//GUI.Label(new Rect(100, 40, Screen.width, 30), "测试滚动视图，测试滚动视图，测试滚动视图，测试滚动视图。");
		
		GUI.Label (new Rect (20, 20, (1200.0f / 1280.0f) * Screen.width, Screen.height),Article,label);
		
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
