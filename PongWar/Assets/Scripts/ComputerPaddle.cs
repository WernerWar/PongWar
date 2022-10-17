using UnityEngine;

public class ComputerPaddle : Paddle
{
	public Rigidbody2D ball;

	private void FixedUpdate()
	{
		if (ball.velocity.x > 0f)
		{
			if (ball.position.y > rigidbody.position.y)
			{
				rigidbody.AddForce(Vector2.up * speed);
			}
			else if (ball.position.y < rigidbody.position.y)
			{
				rigidbody.AddForce(Vector2.down * speed);
			}
		}
		else
		{
			if (rigidbody.position.y > 0f)
			{
				rigidbody.AddForce(Vector2.down * speed);
			}
			else if (rigidbody.position.y < 0f)
			{
				rigidbody.AddForce(Vector2.up * speed);
			}
		}
	}
}
