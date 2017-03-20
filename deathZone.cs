using UnityEngine;
using System.Collections;

public class deathZone : MonoBehaviour
{
	void OnTriggerEnter2D (Collider2D other)
	{
		DestroyObject (other.gameObject);
	}
}
