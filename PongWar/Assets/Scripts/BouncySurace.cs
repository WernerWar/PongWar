using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncySurace : MonoBehaviour
{
    public float bounceStrength = 1.0f;

	private void OnCollisionEnter2D(Collision2D collision)
	{
		Ball ball = collision.gameObject.GetComponent<Ball>();

		if (ball != null)
		{
			Vector2 normal = collision.GetContact(0).normal;
			ball.GetComponent<Rigidbody2D>().AddForce(-normal * bounceStrength, ForceMode2D.Impulse);
		}
	}
}
