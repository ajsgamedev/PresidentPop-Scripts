using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{

	// make game manager public static so can access this from other scripts
	public static GameManager gm;

	public AudioSource crowd;
	public AudioSource song;
	public AudioSource boo;
	public AudioSource cheer;
	public AudioSource loseSound;

	public float startTime = 35.0f;
	public Text mainTimer;

	private float currentTime;

	public GameObject Win;
	public GameObject Lose;
	public GameObject ResetGame;
	public GameObject ExitGame;
	public GameObject BalloonSpawners;
	public GameObject Player;
	public GameObject goodEndGameObjects;
	public GameObject badEndGameObjects;
	public GameObject UIBackground;

	public bool whiteBalloonPopped = false;

	AudioSource music;

	private double finalScore;

	void Awake ()
	{
		
		Win.SetActive (false);
		Lose.SetActive (false);
		ResetGame.SetActive (false);
		ExitGame.SetActive (false);
		goodEndGameObjects.SetActive (false);
		badEndGameObjects.SetActive(false);

		BalloonSpawners.SetActive (true);
		Player.SetActive (true);
	}

	// setup the game
	void Start ()
	{
		currentTime = startTime + 2.0f;
		// get a reference to the GameManager component for use by other scripts
		if (gm == null)
			gm = this.gameObject.GetComponent<GameManager> ();

	}

	// this is the main game event loop
	void Update ()
	{
		if (currentTime < 0)
		{
			mainTimer.text = "0.00";
			if (ScoreManager.score >= 220.0)
			{  // check to see if beat game
				finalScore = ScoreManager.score;
				GoodEndGame ();
			}
			else
			{
				finalScore = ScoreManager.score;
				BadEndGame ();
			}
		}
		else
		{
			
			currentTime -= Time.deltaTime;
			mainTimer.text = currentTime.ToString ("0.00");
		}

	}

	void FixedUpdate()
	{
		if (whiteBalloonPopped == true)
		{
			currentTime += 2.0f;
			whiteBalloonPopped = false;
		}
	}

	public void GoodEndGame ()
	{
		// game is over

		Win.SetActive (true);
		ResetGame.SetActive (true);
		ExitGame.SetActive (true);
		goodEndGameObjects.SetActive (true);

		BalloonSpawners.SetActive (false);
		Player.SetActive (false);
		UIBackground.SetActive (false);

		ScoreManager.score = finalScore;
		crowd.volume = 0.1f;
		song.volume = 0.6f;
		song.pitch = 0.8f;
	}

	public void BadEndGame ()
	{
		// game is over

		Lose.SetActive (true);
		ResetGame.SetActive (true);
		ExitGame.SetActive (true);
		badEndGameObjects.SetActive (true);

		BalloonSpawners.SetActive (false);
		Player.SetActive (false);
		UIBackground.SetActive (false);

		ScoreManager.score = finalScore;
		crowd.volume = 0.1f;
		song.volume = 0.3f;
		song.pitch = 0.8f;
	}

	public void ResetLevel ()
	{
		SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
	}


	// public function that can be called to exit the game
	public void ReturnToMainMenu ()
	{
		
		SceneManager.LoadScene ("MainMenu");

	}
		

}
