using UnityEngine;
using System.Collections;

public class PlayerPhysics2d : MonoBehaviour {

	public int force;
	public int movement;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{

		if (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Began) 
		{
			gameObject.rigidbody2D.AddForce(new Vector3(0, force, 0));
		}

		gameObject.rigidbody2D.AddForce(new Vector3(movement, 0, 0));


		
		if (Input.GetKeyUp(KeyCode.Space)) 
		{
			gameObject.rigidbody2D.AddForce(new Vector3(0, force, 0));
		}


	
	}

	void OnCollisionEnter (Collision col)
	{
		if (col.collider.tag == "Wall_Right" || col.collider.tag == "Wall_Left") 
		{
			movement = -movement;

		}
	}
}
