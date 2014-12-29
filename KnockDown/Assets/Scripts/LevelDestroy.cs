/// <summary>
/// Level destroy.
/// This script destroys the gameobject which tallies up the levels
/// </summary>
using UnityEngine;
using System.Collections;

public class LevelDestroy : MonoBehaviour {

	public int levelNum;
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
		if(levelNum == ballPhysics.level)
		{
//			Destroy(gameObject);
//			gameObject.SetActive (false);
			gameObject.collider.enabled = false;
		}

		else if(ballPhysics.level == 0)
		{
//			gameObject.SetActive (true);
			gameObject.collider.enabled = true;
		}
	
	}
}
