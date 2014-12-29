using UnityEngine;
using System.Collections;

public class Game_Bounds: MonoBehaviour {

	public int force;
	public int movement;

	// Use this for initialization
	void Start () 
	{
	
	}

	void Update()
	{
		if(Input.GetKeyUp(KeyCode.Escape))
		{
			Application.Quit();
		}
	}
	//When ball collides with wall
	void OnCollisionEnter (Collision col)
	{
		//Check to see tag
		if (col.collider.tag == "Bounds_Out" || col.collider.tag == "Obstacle") 
		{
			//reset position to default
			gameObject.transform.position = new Vector3(1.883953f, -4.130527f, 0f);

		}
	}
}
