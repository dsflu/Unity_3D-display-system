using UnityEngine;
using System.Collections;

public class touch_rotate_ZJU : MonoBehaviour {

	public GameObject obj;
	public GameObject center ;

	float touchDeltaX = 0;
	float touchDeltaY = 0;

	bool operation_type = true;
	//Scale
	float olddis = 0;
	float newdis = 0;
	float scaleSpeed = 0.05f;

	// Use this for initialization
	void Start () {
		obj = GameObject.Find ("plane_fbx");
		center = GameObject.Find ("plane_fbx/pCube18");
		//obj = GameObject.

	}

	void OnGUI()
	{
		if (GUI.Button (new Rect((920.0f/1280.0f)*Screen.width, (740.0f/800.0f)*Screen.height, (200.0f/1280.0f)*Screen.width, (50.0f/800.0f)*Screen.height),"平移or旋转")){
			if(operation_type == true)
				operation_type = false;
			else if(operation_type == false)
				operation_type = true;
		}
		if (GUI.Button (new Rect((220.0f/1280.0f)*Screen.width , (740.0f/800.0f)*Screen.height , (220.0f/1280.0f)*Screen.width, (50.0f/800.0f)*Screen.height),"回到默认视角")) 
			Application.LoadLevel("True3D_plane");
	}
	
	// Update is called once per frame
	void Update () {

//		if (center != null) {
////			obj.transform.RotateAround (center.transform.position, Vector3.up, Time.deltaTime * 50);
//			obj.transform.RotateAround(center.transform.position, Vector3.up, 20);
//		} else {
//			Debug.Log("Not find center");
//		}



		if (Input.touchCount == 1 && operation_type == true)
		{
			if (Input.GetTouch(0).phase == TouchPhase.Moved)
			{
				//获取手指自最后一帧的移动
				Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
				
				touchDeltaX += touchDeltaPosition.x;
				touchDeltaY += touchDeltaPosition.y;
				
				//				Debug.Log("dx :" + touchDeltaPosition.x + "dy:" + touchDeltaPosition.y);
				
				int delyXParameter = 5;
				int delyYParameter = 10;
				
				if(touchDeltaX > delyXParameter){ // 向右滑动
					
					touchDeltaX = 0;
					
					// 物体向左转
//					obj.transform.Rotate(0, -2, 0);
					obj.transform.RotateAround(center.transform.position, Vector3.up, -2);

				}else if(touchDeltaX < -delyXParameter){
					
					touchDeltaX = 0;
					
					// 物体向右转
//					obj.transform.Rotate(0, 2, 0);
					obj.transform.RotateAround(center.transform.position, Vector3.up, 2);
				}
				
				if(touchDeltaY > delyYParameter){ // 向上滑动
					
					touchDeltaY = 0;
					
					// 物体向上
//					obj.transform.Rotate(0, 0, 2);
					obj.transform.RotateAround(center.transform.position, Vector3.right, 2);

				}else if(touchDeltaY < -delyYParameter){
					
					touchDeltaY = 0;
					
//					obj.transform.Rotate(0, 0, -2);
					obj.transform.RotateAround(center.transform.position, Vector3.right, -2);
				}
			}        
		}

		if (Input.touchCount == 1 && Input.GetTouch (0).phase == TouchPhase.Moved && operation_type == false) 
		{
			Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
			//touchDeltaPosition.x;
			//touchDeltaPosition.y;
			int delyXParameter = 5;
			int delyYParameter = 10;

			if(touchDeltaPosition.x > delyXParameter)
			{
				obj.transform.Translate(new Vector3(0.05f,0,0),Space.World);
				Debug.Log (touchDeltaX);
			}
			if(touchDeltaPosition.x < -delyXParameter)
			{
				obj.transform.Translate(new Vector3(-0.05f,0,0),Space.World);
				Debug.Log (touchDeltaX);
			}
			if(touchDeltaPosition.y > delyYParameter)
			{
				obj.transform.Translate(new Vector3(0,0.05f,0),Space.World);
				Debug.Log (touchDeltaY);
			}
			if(touchDeltaPosition.y < -delyYParameter)
			{
				obj.transform.Translate(new Vector3(0,-0.05f,0),Space.World);
				Debug.Log (touchDeltaY);
			}


		}

		if (Input.touchCount > 1) {
			if (Input.GetTouch (0).phase == TouchPhase.Moved ||
				Input.GetTouch (1).phase == TouchPhase.Moved) {
				var pos1 = Input.GetTouch (0).position;
				var pos2 = Input.GetTouch (1).position;
				newdis = Vector2.Distance (pos1, pos2);
				if (olddis != null) {
					if (newdis < olddis) {
						//_model.transform.Translate(new Vector3(0,0,scaleSpeed));
						//float curOrthographicSize = Camera.main.GetComponent<Camera>().orthographicSize + scaleSpeed;
						//Camera.main.GetComponent<Camera>().orthographicSize = curOrthographicSize;
						Camera.main.GetComponent<Transform>().position -= new Vector3(0,0,scaleSpeed);
					}
					if (newdis > olddis) {
						//_model.transform.Translate(new Vector3(0,0,-scaleSpeed));
						//float curOrthographicSize = Camera.main.GetComponent<Camera>().orthographicSize - scaleSpeed;
						//Debug.Log(curOrthographicSize);
						//Camera.main.GetComponent<Camera>().orthographicSize = curOrthographicSize;
						Camera.main.GetComponent<Transform>().position += new Vector3(0,0,scaleSpeed);
					}
				}
				olddis = newdis;
			}
		}



	}
}
