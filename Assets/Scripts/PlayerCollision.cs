using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour {

	Rigidbody2D rb;
	public float bounciness = 1.75f;

	private void Awake()
	{
		rb = gameObject.GetComponent<Rigidbody2D>();
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
	
		if (collision.collider.tag == "Player")
		{
			Rigidbody2D rbc = collision.collider.GetComponent<Rigidbody2D>();

			Vector2 displacement = rbc.transform.position - rb.transform.position;

			displacement = displacement.normalized;

			Vector2 player2v = displacement * bounciness * rb.velocity.x * rb.velocity.x;

			Vector2 player1v = -displacement * bounciness * rbc.velocity.x * rbc.velocity.x;

			//When using Velocity use bounciness around 1.75
			//rb.velocity = player1v;
			//rbc.velocity = player2v;

			//When using force use bounciness around 30
			rb.AddForce(player1v);
			rbc.AddForce(player2v);
		}
	}

}
