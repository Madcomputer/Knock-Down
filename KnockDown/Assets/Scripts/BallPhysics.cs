using UnityEngine;
using System.Collections;

public class BallPhysics : MonoBehaviour {

	public int forceY;
	public int forceX;
	//LOLOLOLOLOL
	public float movement;
	public float accelerometerSpeed;

	public GameObject deathParticles;
	public AudioClip deathSound;

	public bool tapped;
	public bool grounded = true;


	public AudioClip jumpSound;
	public AudioClip wallSound;
	public int level;

	/// <summary>
	/// The distance traveled by the player.
	/// </summary>
	public static float distanceTraveled;

	// Use this for initialization
	void Start () 
	{
		level = 0;
		tapped = false;
	}

	// Update is called once per frame
	void Update () 
	{

		distanceTraveled = transform.localPosition.y;

		if (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Began && grounded == true) 
		{
			if(movement > 0f)
			{
				audio.PlayOneShot(jumpSound);
				gameObject.rigidbody.AddForce(new Vector3(0, forceY, 0));
				tapped = true;
			}
			
			else if(movement < 0f)
			{
				audio.PlayOneShot(jumpSound);
				gameObject.rigidbody.AddForce (new Vector3(0,forceY,0));
				tapped = true;
			}
		}

#if UNITY_EDITOR
		gameObject.rigidbody.AddForce(new Vector3(movement, 0f, 0f));
#endif

#if UNITY_ANDROID
		gameObject.rigidbody.AddForce (new Vector3(Input.acceleration.x * accelerometerSpeed , 0f, 0f));
#endif

		
		if (Input.GetKeyUp(KeyCode.Z) && grounded == true) 
		{

				if(movement > 0f)
				{
					audio.PlayOneShot(jumpSound);
					gameObject.rigidbody.AddForce(new Vector3(forceX, forceY, 0));
					tapped = true;
					grounded = false;
					Debug.Log("Movement > 0");
				}

				else if(movement < 0f)
				{
					audio.PlayOneShot (jumpSound);
					gameObject.rigidbody.AddForce (new Vector3(-forceX,forceY,0));
					tapped = true;
					grounded = false;
					Debug.Log("Movement < 0");
				}
		}


	
	}

	void OnCollisionEnter (Collision col)
	{
		if (col.collider.tag == "Wall_Right" || col.collider.tag == "Wall_Left") 
		{
			audio.PlayOneShot(wallSound);
			movement = -movement;

		}

		//Check to see tag
		else if (col.collider.tag == "Bounds_Out" || col.collider.tag == "Obstacle") 
		{
			//reset position to default
			level = 0;
			gameObject.transform.position = new Vector3(1.883953f, -4.130527f, 0f);
			Handheld.Vibrate();
			
		}

		//Jumping restriction
		if (col.collider.tag == "Floor") 
		{
			//grounded = true;
				
		} 

		else if (col.collider.tag == "Wall_Right" || col.collider.tag == "Wall_Left") 
		{
			//grounded = true;
		}

		else 
		{
			//grounded = false;
		}
	}

	void OnCollisionExit(Collision col)
	{
		grounded = false;
	}
	



	void OnTriggerEnter(Collider collider)
	{
	
		if (collider.tag == "Spike") 
		{
			audio.PlayOneShot(deathSound);
			Instantiate (deathParticles, transform.position, Quaternion.identity);
			//Destroy (gameObject);
			movement = -movement;
			level = 0;
			gameObject.transform.position = new Vector3(1.883953f, -4.130527f, 0f);
			Handheld.Vibrate();
		}

		else if(collider.tag == "LevelUp")
		{
			level++;

		}
	}



}
