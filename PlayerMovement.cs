using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	[Range (0.0f, 10.0f)] // create a slider in the editor and set limits on moveSpeed
	public float moveSpeed = 3f;

	Transform _transform;
	Rigidbody2D _rigidbody;


	float _vx;
	bool facingRight = true;


	// Use this for initialization
	void Awake () {

		_transform = GetComponent<Transform> ();
		_rigidbody = GetComponent<Rigidbody2D> ();
	
	}
	
	// Update is called once per frame
	void Update () {

		_vx = Input.GetAxis ("Horizontal");

		_rigidbody.velocity = new Vector2 (_vx * moveSpeed, 0.0f);
	
	}

	void LateUpdate ()
	{
		// get the current scale
		Vector3 localScale = _transform.localScale;

		if (_vx > 0) // moving right so face right
		{
			facingRight = true;
		}
		else
			if (_vx < 0)
			{ // moving left so face left
				facingRight = false;
			}

		// check to see if scale x is right for the player
		// if not, multiple by -1 which is an easy way to flip a sprite
		if (((facingRight) && (localScale.x < 0)) || ((!facingRight) && (localScale.x > 0)))
		{
			localScale.x *= -1;
		}

		// update the scale
		_transform.localScale = localScale;
	}
}
