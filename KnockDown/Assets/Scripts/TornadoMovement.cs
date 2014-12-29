using UnityEngine;
using System.Collections;

public class TornadoMovement : MonoBehaviour {

	public Vector3 pointB;
	public float time;

	
	IEnumerator Start () 
	{
		Vector3 pointA = transform.position;
	
		while (true) 
		{
			yield return StartCoroutine(MoveObject(transform, pointA, pointB, time));
			yield return StartCoroutine(MoveObject(transform, pointB, pointA, time));
		}
	}
	
	IEnumerator MoveObject (Transform thisTransform, Vector3 startPos, Vector3 endPos, float time) 
	{
		float i = 0.0f;
		float rate = 1.0f / time;
	
		while (i < 1.0f) 
		{
			i += Time.deltaTime * rate;
			thisTransform.position = Vector3.Lerp(startPos, endPos, i);
			yield return null; 
		}
	}
}