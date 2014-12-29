/// <summary>
/// Camera movement.
/// This script allows the camera to move up levels as the player does.
/// The script accesses the "BallPhysics" class' level(int) variable inorder to identify what level the player is on. 
///Based on which one the player will be at, the camera will change/zoom to the next level. 
/// </summary>

using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour 
{
	public GameObject ball;
	private BallPhysics ballPhysics;


	// Use this for initialization
	void Start () 
	{
		ballPhysics = ball.GetComponent<BallPhysics>();
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(ballPhysics.level == 1)
		{
			transform.position = new Vector3(0f, 2.5f,-10f); 
		}

		else if(ballPhysics.level == 2)
		{
			transform.position = new Vector3(0f, 5.0f,-10f); 
		}

		else if(ballPhysics.level == 3)
		{
			transform.position = new Vector3(0f, 7.5f,-10f); 
		}

		else if(ballPhysics.level == 4)
		{
			transform.position = new Vector3(0f, 10.0f,-10f); 
		}

		else if(ballPhysics.level == 0)
		{
			transform.position = new Vector3(0f, 0f, -10f);
		}


	
	}
}
