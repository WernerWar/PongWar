using UnityEngine;

public class Paddle : MonoBehaviour
{
	public float speed = 10f;

	[HideInInspector]
	public Rigidbody2D rigidbody;

	private void Awake()
	{
		rigidbody = GetComponent<Rigidbody2D>();
	}

	public void ResetPosition()
	{
		rigidbody.velocity = Vector2.zero;
		rigidbody.position = new Vector2(rigidbody.position.x, 0f);
	}
}

