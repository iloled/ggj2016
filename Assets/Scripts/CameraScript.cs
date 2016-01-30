using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {



	[SerializeField]
	Camera myCamera;

	RaycastHit hit;
	Ray ray;

	float speed = 20f;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		ray = myCamera.ScreenPointToRay(Input.mousePosition);


		if(Input.GetKey(KeyCode.RightArrow))
		{
			transform.Translate(new Vector3(speed * Time.deltaTime,0,0));
		}
		if(Input.GetKey(KeyCode.LeftArrow))
		{
			transform.Translate(new Vector3(-speed * Time.deltaTime,0,0));
		}
		if(Input.GetKey(KeyCode.DownArrow))
		{
			transform.Translate(new Vector3(0,-speed * Time.deltaTime,0));
		}
		if(Input.GetKey(KeyCode.UpArrow))
		{
			transform.Translate(new Vector3(0,speed * Time.deltaTime,0));
		}
	}

	public bool checkHit()
	{
		bool hasHitted = false;

		if (Physics.Raycast (ray, out hit)) 
		{
			if(hit.transform != null){
				hasHitted = true;
			} 
			else
			{
				hasHitted = false;
			}
		} 
		return hasHitted;
	}
	
	public int GetPostionTile()
	{
		int pos = 0;
		
		if (Physics.Raycast (ray, out hit)) {

			int x = (int) hit.transform.position.x - 1 ;
			int y = (int) hit.transform.position.y - 1;
			pos = ((y*32) + x)-32-1;
		}

		return pos;
	}
}
	