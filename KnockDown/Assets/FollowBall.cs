using UnityEngine;
using System.Collections;

public class FollowBall : MonoBehaviour {

	public Transform ball;
	public Transform cameraPosition;
	public float smooth = 5.0f;
	public Vector2 velocity;
	// Use this for initialization
	void Start () 
	{
		//Camera.main.transform.position = cameraPosition.position;

	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.position = new Vector3(transform.position.x, ball.position.y, transform.position.z);//ball.position.y;//Vector3.Lerp (transform.position.y, ball.position, Time.deltaTime * smooth);

	}
	

}
