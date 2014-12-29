using UnityEngine;
using System.Collections;

public class Rays : MonoBehaviour {

	private BallPhysics ballPhysics;
	public GameObject ball;
	private int i = 0;

	// Use this for initialization
	void Start () 
	{
		ballPhysics = ball.GetComponent<BallPhysics>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		//Vector3 dwn = transform.TransformDirection (Vector3.down);
		//Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);

		RaycastHit hit;
		Ray ray = new Ray (transform.position, Vector3.down);
		Color color = Color.red;


		if (Physics.Raycast (ray, out hit, 0.5f)) 
		{//float distanceToGround = hit.distance;
						color = Color.green;
						ballPhysics.grounded = true;
			Debug.DrawRay (transform.position, Vector3.down, color);
		} 
		else 
		{
			color = Color.red;
		}
			

		
	}
}
