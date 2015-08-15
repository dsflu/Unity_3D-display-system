using UnityEngine;
using System.Collections;

public class bg: MonoBehaviour
{
	public GameObject plane;
	public GameObject cam;
	//Vector3 cam_scale ;

	void Start()
	{
		plane = GameObject.Find ("Plane");
		cam = GameObject.Find ("BackgroundCamera");
		//cam.
		//plane.GetComponent<RectTransform> ().localScale = new Vector3(Screen.width*0.0015f,1.0f,Screen.height*0.0015f);

	}

	void Update()
	{
		//GetComponent<Camera> ().orthographicSize = 4;
	}
	

}
