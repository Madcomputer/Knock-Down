/// <summary>
/// Platform manager.
/// Procedurally generates platforms based on values provided. Based on algorithms(if any) used in infinite runners, 
/// 
/// 
/// </summary>
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlatformManager : MonoBehaviour {

	public Transform prefab;
	public int numberOfObjects;
	public float recycleOffset;
	public Vector3 startPosition;
	public Vector3 buffer;
	public Vector3 minSize, maxSize, minGap, maxGap;
	public float minX, maxX;

	private Vector3 nextPosition;
	private Queue<Transform> objectQueue;

	

	// Use this for initialization
	void Start () 
	{
		objectQueue = new Queue<Transform> (numberOfObjects);
		for (int i = 0; i < numberOfObjects; i++) 
		{
			objectQueue.Enqueue((Transform)Instantiate(prefab));
		}

		nextPosition = startPosition;	
		for (int i = 0; i < numberOfObjects; i++) 
		{
			Recycle();
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (objectQueue.Peek().localPosition.y + recycleOffset < BallPhysics.distanceTraveled) 
		{
			Recycle();
		}
	
	}

	private void Recycle() 
	{
		Vector3 scale = new Vector3 (
			Random.Range (minSize.x, maxSize.x),
			Random.Range (minSize.y, maxSize.y),
			Random.Range (minSize.z, maxSize.z));

		Vector3 position = nextPosition;
		position.x += scale.x * 0.5f;
		position.y += scale.y * 0.5f;

		Transform o = objectQueue.Dequeue();
		o.localScale = scale;
		o.localPosition = position;
		objectQueue.Enqueue (o);

		nextPosition += new Vector3 (
			Random.Range (minGap.x, maxGap.x),
			Random.Range (minGap.y, maxGap.y) + scale.y,
			Random.Range (minGap.z, maxGap.z));


		if (nextPosition.x < minX) 
		{
			nextPosition.x = minX + maxGap.x;
		} 

		else if (nextPosition.x > maxX) 
		{
			nextPosition.x = maxX - maxGap.x;
		}
	}
}
