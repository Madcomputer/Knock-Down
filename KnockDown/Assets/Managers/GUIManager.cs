using UnityEngine;
using System.Collections;

public class GUIManager : MonoBehaviour {


	public GUIText gameOverText, instructionsText, runnerText;

	// Use this for initialization
	void Start () 
	{
		GameEventManager.GameStart += GameStart;
		GameEventManager.GameOver += GameOver;
		gameOverText.enabled = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetButtonDown("Jump"))
		{
			GameEventManager.TriggerGameStart();
		}

		if (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Began) 
		{
			GameEventManager.TriggerGameStart();
		}
	
	}

	private void GameStart()
	{
		gameOverText.enabled = false;
		instructionsText.enabled = false;
		runnerText.enabled = false;
		enabled = false;
	}

	private void GameOver()
	{
		gameOverText.enabled = true;
		instructionsText.enabled = true;
		enabled = true;
	}
}
