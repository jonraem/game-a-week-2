using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	private bool showWinScreen = false;
	private bool completed = false;

	public float currentTime;
	public string timeText;
	public int inputCounter;

	// Update is called once per frame
	void Update () {
		if (!completed)
		{
			currentTime += Time.deltaTime;
			timeText = string.Format ("{0:0:00}", currentTime);
		}

		if (Input.GetKeyDown(KeyCode.Escape))
		{
			Application.LoadLevel(Application.loadedLevel);
		}
	}

	public void CompleteLevel(int input)
	{
		if (!completed)
		{
			inputCounter = input;
		}
		showWinScreen = true;
		completed = true;
	}

	void OnGUI()
	{
		if (showWinScreen)
		{
			GUI.Label(new Rect(150, 150, 500, 500), "Congratulations! You have completed the level.\nYour time was " + timeText + " and you died " + inputCounter.ToString() + " times.\n\nPress Escape to restart the game.");
		}
	}
}
