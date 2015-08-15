using UnityEngine;
using System.Collections;

public class Image3DViewer : MonoBehaviour {

	/* public */

	public int sceneNum;

	/* private */

	Texture2D image;

	int xIndex = 0;
	int yIndex = 0;

	float touchDeltaX = 0;
	float touchDeltaY = 0;

	ArrayList imageMetas;

	// 四个group代表四个不同的仰角下拍摄的照片
	int groupCount; // array 0 1
	
	// 23张picture是在同一个仰角下,左右不同角度拍摄的照片
	int pictureCount; // array 0 ... 21

	// Use this for initialization
	void Start () {
//		image = (Texture2D)Resources.Load("test");
		imageMetas = new ArrayList();

		ArrayList imageMeta_0 = new ArrayList();
		imageMeta_0.Add (21);
		imageMeta_0.Add (29);
		imageMetas.Add (imageMeta_0);

		ArrayList imageMeta_1 = new ArrayList();
		imageMeta_1.Add (11);
		imageMetas.Add (imageMeta_1);

		ArrayList imageMeta_2 = new ArrayList();
		imageMeta_2.Add (19);
		imageMetas.Add (imageMeta_2);

		ArrayList imageMeta_3 = new ArrayList();
		imageMeta_3.Add (20);
		imageMetas.Add (imageMeta_3);

		ArrayList temp;

		temp = imageMetas[sceneNum] as ArrayList;

		groupCount = temp.Count - 1;
		pictureCount = (int)temp[0];

	}
	
	// Update is called once per frame
	void Update () {

		if (Input.touchCount > 0)
		{
			if (Input.GetTouch(0).phase == TouchPhase.Moved)
			{
				//获取手指自最后一帧的移动
				Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;

				touchDeltaX += touchDeltaPosition.x;
				touchDeltaY += touchDeltaPosition.y;

//				Debug.Log("dx :" + touchDeltaPosition.x + "dy:" + touchDeltaPosition.y);

				int delyXParameter = 10;
				int delyYParameter = 20;

//				 更新 xindex 和 yindex
				if(touchDeltaX > delyXParameter){ // 向右滑动

					touchDeltaX = 0;

					// 物体向左转
					if (xIndex>0){
						xIndex--;
					}else{
						xIndex=pictureCount;
					}
				}else if(touchDeltaX < -delyXParameter){

					touchDeltaX = 0;

					// 物体向右转
					if (xIndex<pictureCount){
						xIndex++;
					}else{
						xIndex=0;
					}
				}

				if(touchDeltaY > delyYParameter){ // 向上滑动

					touchDeltaY = 0;
					
					// 物体向上
					if (yIndex<groupCount){
						yIndex++;

						ArrayList temp;						
						temp = imageMetas[sceneNum] as ArrayList;
						pictureCount = (int)temp[yIndex];

//						pictureCount = imageMetas [sceneNum] [yIndex];
//						pictureCount = ((ArrayList)imageMetas.ToArray[sceneNum]).ToArray[yIndex];

//						if(yIndex == 0){
//							pictureCount = 21;
//						}else if(yIndex == 1){
//							pictureCount = 29;
//						}
					}
				}else if(touchDeltaY < -delyYParameter){

					touchDeltaY = 0;

					if (yIndex>0){
						yIndex--;

						ArrayList temp;						
						temp = imageMetas[sceneNum] as ArrayList;
						pictureCount = (int)temp[yIndex];

//						pictureCount = ((ArrayList)imageMetas.ToArray[sceneNum]).ToArray[yIndex];

//						if(yIndex == 0){
//							pictureCount = 21;
//						}else if(yIndex == 1){
//							pictureCount = 29;
//						}
					}
				}
			}        
		}
	}

	void OnGUI(){

//		根据xindex 和 yindex 得到图片的文件名
		string imageName = "img_" + xIndex + "_" + yIndex;
//		image = (Texture2D)Resources.Load (imageName);
		image = (Texture2D)Resources.Load("example_" + sceneNum + "/" + imageName);

		if(!image){
			//如果不指定图片会输出这条消息
			Debug.Log("xIndex:" + xIndex + "yIndex:" + yIndex + " 请指定一个纹理图片" + "example_0/" + imageName);
			return;
		}



		if (sceneNum == 0) {
			GUIUtility.RotateAroundPivot (90, new Vector2 (Screen.width / 2, Screen.height / 2));
		}

		GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), image, ScaleMode.StretchToFill, true, 0);	
		if (sceneNum == 0) {
			GUIUtility.RotateAroundPivot (-90, new Vector2 (Screen.width / 2, Screen.height / 2));
		}
		if (GUI.Button (new Rect (0 , 0 , Screen.width/8 , Screen.height/8), "Return")) {
			Application.LoadLevel("main_ZJU");
		}
//		GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), image, ScaleMode.StretchToFill, true, 0);	



	}
}
