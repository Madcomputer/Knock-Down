using UnityEngine;
using System.Collections;

public class Test : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void OnTriggerEnter (Collider ball) 
	{
		if (ball.collider.tag == "Player") 
		{
			Debug.Log ("Colided");
		}
	
	}
}
