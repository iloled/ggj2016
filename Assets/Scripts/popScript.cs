using UnityEngine;
using System.Collections;

public class popScript : MonoBehaviour {

	[SerializeField]
	Transform[] prefabPop;


	public void popFire(int TileID)
	{
		var x = TileID%32;
		var y = TileID/32;
		
		Instantiate (prefabPop [0], new Vector3 (1 + x, 1 + y, 0.0f), Quaternion.identity);
	}

	public void popConvert(int TileID)
	{
		var x = TileID%32;
		var y = TileID/32;
		
		Instantiate (prefabPop [1], new Vector3 (1 + x, 1 + y, 0.0f), Quaternion.identity);
	}

	public void popSlash(int TileID)
	{
		var x = TileID%32;
		var y = TileID/32;
		
		Instantiate (prefabPop [2], new Vector3 (1 + x, 1 + y, 0.0f), Quaternion.identity);
	}

	/*void Update()
	{
		if(Input.GetKeyDown(KeyCode.Z))
		{
			popFire(33);
		}
		if(Input.GetKeyDown(KeyCode.Q))
		{
			popConvert(33);
		}
		if(Input.GetKeyDown(KeyCode.S))
		{
			popSlash(33);
		}
	}*/





}
