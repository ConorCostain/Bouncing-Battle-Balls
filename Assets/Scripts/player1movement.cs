using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player1movement : MonoBehaviour {

	Rigidbody2D rb;
	public GameManager gm;

	public float acceleration = 1f;
	public float maxSpeed = 10f;
	
	public float jumpPower = 20f;
	public float gravityMultiplier = 2.5f;
	public float turnSpeed = 5f;

	
	private bool moveLeft;
	private bool moveRight;
	private bool moveJump;


	private void Awake()
	{
		rb = gameObject.GetComponent<Rigidbody2D>();	
	}

	// Update is called once per frame
	void Update ()
	{
		moveJump = Input.GetKey("w");
		moveRight = Input.GetKey("d");
		moveLeft = Input.GetKey("a");

		if (Input.GetKey("escape"))
			PlaySessionManager.ins.LoadScene("MainMenu");

	}

	void FixedUpdate()
	{
		Movement.movementFixedUpdate(moveLeft, moveRight, moveJump, turnSpeed, maxSpeed, acceleration, gravityMultiplier, jumpPower, rb);

		if (rb.position.y < -5)
			PlaySessionManager.ins.RoundOver(2);
		
	}

	


	
}
