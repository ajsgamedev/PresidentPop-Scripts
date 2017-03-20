using UnityEngine;
using System.Collections;

public class BalloonBehave : MonoBehaviour
{

	Rigidbody2D rb;

	public GameObject BalloonExplosion;

	private float blueB = 1.0f;
	private float redB = -0.5f;
	private float starB = 10f;
	private float bigRedB = -5f;


	void Awake ()
	{
		rb = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		rb.velocity = new Vector2 (0.0f, -1.0f);

		if (ScoreManager.score >= 150)
		{
			this.gameObject.GetComponent<Rigidbody2D> ().gravityScale = 5;
		}
		else
		if (ScoreManager.score >= 210)
		{
			this.gameObject.GetComponent<Rigidbody2D> ().gravityScale = 10;
		}
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.tag == "Player")
		{
			if (this.gameObject.tag == "BalloonBlue")
			{
				ScoreManager.score += blueB;
				GameManager.gm.cheer.Play ();
				Instantiate (BalloonExplosion, transform.position, transform.rotation);
			}
			else
			if (this.gameObject.tag == "BalloonRed")
			{
				ScoreManager.score += redB;
				GameManager.gm.boo.Play ();
				Instantiate (BalloonExplosion, transform.position, transform.rotation);
			}
			else
			if (this.gameObject.tag == "BalloonStar")
			{
				ScoreManager.score += starB;
				GameManager.gm.cheer.Play ();
				Instantiate (BalloonExplosion, transform.position, transform.rotation);
			}
			else
			if (this.gameObject.tag == "BalloonWhite")
			{
				GameManager.gm.whiteBalloonPopped = true;
				Instantiate (BalloonExplosion, transform.position, transform.rotation);
			}
			else
			if (this.gameObject.tag == "BalloonBigRed")
			{
				ScoreManager.score += bigRedB;
				GameManager.gm.boo.Play ();
				Instantiate (BalloonExplosion, transform.position, transform.rotation);
			}
			DestroyObject (this.gameObject);
		}

	}
}
