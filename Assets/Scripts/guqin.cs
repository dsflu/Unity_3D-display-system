using UnityEngine;
using System.Collections;

public class guqin : MonoBehaviour {

	//音乐文件  
	public AudioSource music;     
	//音量  
	public float musicVolume;  
	
	//public GameObject _plane; //挂一个用来显示图片的plane
	public Texture2D[] _txtAll; //挂载图片
	
	private float screen_width;
	private float screen_height;
	
	private int _index = 0;
	private int timestamp = 21;
	
	//滑动切换图片
	private Vector2 touchFirst = Vector2.zero;
	private Vector2 touchSecond = Vector2.zero;
	
	private string[] des;
	private int index_music;
	private int count_music;
	
	// Use this for initialization
	void Start () {
	
		index_music = 0;
		count_music = Camera.main.GetComponents<AudioSource> ().Length -1;
		music = Camera.main.GetComponents<AudioSource> ()[index_music];
		//设置默认音量  
		musicVolume = 0.5F;

		screen_width = Screen.width;
		screen_height = Screen.height;
		
		if (_txtAll.Length == 0) {
			
			var textures = Resources.LoadAll("imgscan/古琴");
			int count = textures.Length;
			_txtAll = new Texture2D[count];
			des = new string[count];
			for(int i=0; i<count; i++)
			{
				_txtAll[i] = textures[i] as Texture2D;
				des[i] = textures[i].name ;
				//Debug.Log(des[i]);
			}
		}
		
		//_plane.GetComponent<Renderer>().material.mainTexture = _txtAll [0];
	}
	
	// Update is called once per frame
	void Update () {
		
		//回到主菜单
		if (Input.GetKey(KeyCode.Escape)) {
			
			Application.LoadLevel("Start_Scene");
		}
		
		timestamp++;
		//移动
		if (Input.touchCount == 2 && Input.GetTouch (0).phase == TouchPhase.Moved && timestamp>20) {
			timestamp = 0;
			//右移
			if (Input.GetTouch (0).deltaPosition.x < 0 - Mathf.Epsilon) {
				_index = _index == _txtAll.Length - 1 ? -1 : _index;
				_index++;
			}
			else {//左移
				_index = _index == 0 ? _txtAll.Length : _index;
				_index--;
			}
			
		}
		
	}
	
	void OnGUI(){
		//-----------------------------------------------------------------
		//播放音乐按钮  
		if (GUI.Button(new Rect(screen_width-300, 10, 90, 50), "播放音乐"))  
		{  
			
			//没有播放中  
			if (!music.isPlaying)
			{  
				//播放音乐  
				music.Play();  
			}  
			
		}  
		
		//关闭音乐按钮  
		if (GUI.Button(new Rect(screen_width-100, 10, 90, 50), "停止音乐"))  
		{  
			
			if (music.isPlaying)
			{  
				//关闭音乐  
				music.Stop();  
			}  
		}  
		//暂停音乐  
		if (GUI.Button(new Rect(screen_width-200, 10, 90, 50), "暂停音乐"))  
		{  
			if (music.isPlaying)
			{  
				//暂停音乐  
				//这里说一下音乐暂停以后  
				//点击播放音乐为继续播放  
				//而停止以后在点击播放音乐  
				//则为从新播放  
				//这就是暂停与停止的区别  
				music.Pause();  
			}  
		}  
		if (GUI.Button(new Rect(screen_width-400, 10, 90, 50), "下一首"))  
		{  
			if (music.isPlaying)
			{  
				//暂停音乐  
				//这里说一下音乐暂停以后  
				//点击播放音乐为继续播放  
				//而停止以后在点击播放音乐  
				//则为从新播放  
				//这就是暂停与停止的区别  
				music.Stop();
				index_music++;
				if(index_music > count_music)
					index_music = 0;
				music = Camera.main.GetComponents<AudioSource> ()[index_music];
				music.Play();

			}  
		}  
		if (GUI.Button(new Rect(screen_width-500, 10, 90, 50), "上一首"))  
		{  
			if (music.isPlaying)
			{  
				//暂停音乐  
				//这里说一下音乐暂停以后  
				//点击播放音乐为继续播放  
				//而停止以后在点击播放音乐  
				//则为从新播放  
				//这就是暂停与停止的区别  
				music.Stop();
				index_music--;
				if(index_music < 0)
					index_music = count_music;
				music = Camera.main.GetComponents<AudioSource> ()[index_music];
				music.Play();
			}  
		}  
		
		//创建一个横向滑动条用于动态修改音乐音量  
		//第一个参数 滑动条范围  
		//第二个参数 初始滑块位置  
		//第三个参数 起点  
		//第四个参数 终点  
		musicVolume = GUI.HorizontalSlider (new Rect(140, 10, 100, 50), musicVolume, 0.0F, 1.0F);  
		
		//将音量的百分比显示出来  
		GUI.Label(new Rect(150, 30, 300, 20), "游戏音量" + (int)(musicVolume * 100) + "%");  
		
		if (music.isPlaying)
		{  
			//音乐播放中设置音乐音量 取值范围 0.0F到 1.0   
			music.volume = musicVolume;  
		}  
		//-----------------------------------------------------------------
		
		int width = _txtAll[_index].width;
		int height = _txtAll [_index].height;
		float scale;
		scale = Mathf.Min (screen_width/width,screen_height/height);
		//GUI.DrawTexture (new Rect((screen_width-width*scale)*0.5f,(screen_height-height*scale)*0.5f,width*scale,height*scale),_txtAll[_index]);
		GUI.DrawTexture (new Rect(0,(150.0f/800.0f)*screen_height,screen_width,screen_height*0.8f),_txtAll[_index]);
		GUI.Label (new Rect(10,(100.0f/800.0f)*screen_height,screen_width,20),des[_index]);
		//GUILayout.Label (des [_index]);
		if (GUI.Button (new Rect (0 , 0 , (200.0f/1280.0f)*screen_width , (50.0f/800.0f)*screen_height), "Return")) {
			Application.LoadLevel("Start_Scene");
		}
	}
	
}



