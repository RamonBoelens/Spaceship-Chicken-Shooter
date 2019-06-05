using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
	public GameObject pauseText;

	bool isPaused = false;


	public void OnButtonPress()
	{
		


		// If game is paused, unpause the game
		if (isPaused)
		{
			Time.timeScale = 1.0f;
			isPaused = false;
			pauseText.SetActive(false);
		}

		//The game gets paused
		else
		{
			Time.timeScale = 0.0f;
			isPaused = true;
			pauseText.SetActive(true);
		}
	}
}
