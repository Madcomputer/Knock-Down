using UnityEngine;
using System.Collections;

public class NewLevel : MonoBehaviour 
{

	public GameObject ballGameobject;
	BallPhysics ballPhysics;
	// Use this for initialization
	void Start () 
	{
		ballPhysics = ballGameobject.GetComponent<BallPhysics> ();
	}

	void OnGUI()
	{
		if (ballPhysics.wonGame) 
		{
			if(GUI.Button (new Rect(Screen.width/1.5f, Screen.height/1.5f, 200f, 200f), "Next Level"))
			{
				Application.LoadLevel("8.0_NextStage");
			}
		}
	}
	// Update is called once per frame
	void Update () 
	{
	
	}
}
