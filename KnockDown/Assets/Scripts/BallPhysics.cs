/// <summary>
/// This script handles all of the physics asscociated with the ball.
/// </summary>

using UnityEngine;
using System.Collections;

public class BallPhysics : MonoBehaviour {

	//Forces used to launch the ball
	public int forceY;
	public int forceX;

	//Speed values used to vary the ball's speed
	public float movement;
	public float accelerometerSpeed;

	//Particles that are emitted when the ball is destroyed
	public GameObject deathParticles;
	public AudioClip deathSound;    

	
	public bool tapped;          //Has the phone screen been tapped?

	public bool grounded = true;  //Is the ball touching the ground? 

	public bool isDestroyed;

	public int health = 0;		//Health to ensure that conditions can be changed such as Line 168

	public AudioClip jumpSound;
	public AudioClip wallSound;
	public int level;    //What level is it?

	/// <summary>
	/// The distance traveled by the player.
	/// </summary>
	public static float distanceTraveled;


	private Vector3 startPosition;

	// Use this for initialization
	void Start () 
	{ 


		isDestroyed = false;
		level = 0;
		tapped = false;



		GameEventManager.GameStart += GameStart;
		GameEventManager.GameOver += GameOver;
		startPosition = transform.localPosition;
		renderer.enabled = false;
		rigidbody.isKinematic = true;
		enabled = false;
	}


	//GameStart method
	private void GameStart()
	{
		distanceTraveled = 0f;
		transform.localPosition = startPosition;
		renderer.enabled = true;
		rigidbody.isKinematic = false;
		enabled = true;
		health++;
	}

	//Gameover method
	private void GameOver()
	{
		renderer.enabled = false;
		rigidbody.isKinematic = true;
		enabled = false;
	}

	// Update is called once per frame
	void Update () 
	{

		distanceTraveled = transform.localPosition.y;



//Only applies to desktop editor
#if UNITY_EDITOR
		//Moving using left and right arrow keys
		gameObject.rigidbody.AddForce(new Vector3(Input.GetAxis ("Horizontal") * accelerometerSpeed, 0f, 0f));
#endif


//Only applies to android phone
#if UNITY_ANDROID
		gameObject.rigidbody.AddForce (new Vector3(Input.acceleration.x * accelerometerSpeed , 0f, 0f));

		//Ball bounce
		//When a touch screen is tapped and the ball is in contact with the floor
		if (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Began && grounded == true) 
		{
			isDestroyed = false;
			
			//For going right
			if(movement > 0f)
			{
				audio.PlayOneShot(jumpSound);
				gameObject.rigidbody.AddForce(new Vector3(0, forceY, 0)); //Bounce up with magnitude of 'forceY'
				tapped = true;			
			}
			
			//For going left
			else if(movement < 0f)
			{
				audio.PlayOneShot(jumpSound);
				gameObject.rigidbody.AddForce (new Vector3(0,forceY,0));
				tapped = true;
			}
			
			
		}

#endif

		//If the Jump button is pressed and the ball is touching the floor 
		if (Input.GetButton("Jump")) 
		{
			isDestroyed = false;

			if(grounded == true)
			{
				audio.PlayOneShot(jumpSound);
				gameObject.rigidbody.AddForce(new Vector3(0, forceY, 0));    //Ball bounces up 
				tapped = true;
				grounded = false;
			}

			


			//For self moving mechanic

		/*		if(movement > 0f)
				{
					audio.PlayOneShot(jumpSound);
					gameObject.rigidbody.AddForce(new Vector3(0, forceY, 0));
					tapped = true;
					grounded = false;
					Debug.Log("Movement > 0");
				}

				else if(movement < 0f)
				{
					audio.PlayOneShot (jumpSound);
					gameObject.rigidbody.AddForce (new Vector3(0,forceY,0));
					tapped = true;
					grounded = false;
					Debug.Log("Movement < 0");
				}
		*/
		}


		//When ball is destroyed, it calls the GameOver Event from the GameEventManager Script
		if(health < 1)
		{
			GameEventManager.TriggerGameOver();
		}




	
	}


	//When the ball interacts with a collider
	void OnCollisionEnter (Collision col)
	{
		//If collided with either walls, play sound effect 
		if (col.collider.tag == "Wall_Right" || col.collider.tag == "Wall_Left") 
		{
			audio.PlayOneShot(wallSound);
			//movement = -movement;

		}

		//If collided with Boundry checkpoints or obstcales
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

	//When ball leaves collision boundry
	void OnCollisionExit(Collision col)
	{
		//Ball is not touching platforms
		grounded = false;
	}
	


	//when ball collides with a trigger
	void OnTriggerEnter(Collider collider)
	{
		//If collided with spike
		if (collider.tag == "Spike") 
		{
			audio.PlayOneShot(deathSound);	//Play death sound effect

			Instantiate (deathParticles, transform.position, Quaternion.identity);   //Spawn death particle prefab

			//Destroy (gameObject);
			//movement = -movement;
			level = 0;
			health--; 
			isDestroyed = true;

			gameObject.transform.position = new Vector3(1.883953f, -4.130527f, 0f); //Return back to default position

			Handheld.Vibrate(); //Vibrates mobile device
		}

		else if(collider.tag == "LevelUp")
		{
			level++;

		}

		else if(collider.tag == "Star")
		{
			Destroy (collider.gameObject);
		}
	}



}
