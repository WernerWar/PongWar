using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Scoring : MonoBehaviour
{
	public UnityEvent scoreTrigger;

	private void OnCollisionEnter2D(Collision2D collision)
	{
		Ball ball = collision.gameObject.GetComponent<Ball>();
		if (ball != null)
		{
			scoreTrigger.Invoke();
		}
	}
}
