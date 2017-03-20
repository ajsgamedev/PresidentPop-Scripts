using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class ScoreManager : MonoBehaviour
{
	public static double score = 55.3;        // The player's score.

	Text text;                      // Reference to the Text component.

	void Awake ()
	{
		// Set up the reference.
		text = GetComponent <Text> ();

		// Reset the score.
		score = 55.3;
	}


	void Update ()
	{
		// Set the displayed text to be the word "Score" followed by the score value.
		if (score < 0)
		{
			score = 0.0;
		}
		if (score >= 180)
		{
			GameManager.gm.song.pitch = 1.1f;
		}
		else
		if (score >= 215)
		{
			GameManager.gm.song.pitch = 1.25f;
		}
		score = Math.Round (score, 2);
		text.text = "Votes: " + score + "M";
	}
}