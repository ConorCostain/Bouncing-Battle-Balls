using UnityEngine;

public static class Movement
{
	public static void movementFixedUpdate(bool moveLeft, bool moveRight, bool moveJump, float turnSpeed, float maxSpeed, float acceleration, float gravityMultiplier, float jumpPower, Rigidbody2D rb)
	{
		if (moveLeft)
		{
			if (rb.velocity.x > -maxSpeed)
				rb.AddForce(Vector2.left * acceleration * Time.deltaTime * (rb.velocity.x > 0 ? turnSpeed : 1));
		}
		if (moveRight)
		{
			if (rb.velocity.x < maxSpeed)
				rb.AddForce(Vector2.right * acceleration * Time.deltaTime * (rb.velocity.x < 0 ? turnSpeed : 1));
		}
		if (moveJump && (rb.velocity.y == 0 || PlayerCollision.instance.inCollision))
		{
			rb.AddForce(Vector2.up * jumpPower);
			PlayerCollision.instance.inCollision = false;
		}
		if(rb.velocity.y > 9)
		{
			rb.velocity = Vector2.up * 9 + Vector2.right *rb.velocity.x;
		}
		else if (rb.velocity.y < 0)
		{

			rb.AddForce(Vector2.up * Physics2D.gravity.y * (gravityMultiplier - 1));
		}
	}
}
