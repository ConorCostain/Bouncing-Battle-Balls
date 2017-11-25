using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player2movement : MonoBehaviour
{

	Rigidbody2D rb;
	public GameManager gm;

	public float acceleration = 150f;
	public float maxSpeed = 10f;
	public float jumpPower = 20f;
	public float gravityMultiplier = 2.5f;
	public float turnSpeed = 5f;

	private bool inAir = true;
	private bool moveLeft;
	private bool moveRight;
	private bool moveJump;


	private void Awake()
	{
		rb = gameObject.GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void Update()
	{
		moveJump = Input.GetKey("up");
		moveRight = Input.GetKey("right");
		moveLeft = Input.GetKey("left");
		
	}

	void FixedUpdate()
	{
		Movement.movementFixedUpdate(moveLeft, moveRight, moveJump, turnSpeed, maxSpeed, acceleration, gravityMultiplier, jumpPower, rb);

		if(rb.position.y < -15)
		{
			gm.EndGame(2);
		}
	}

	
}
