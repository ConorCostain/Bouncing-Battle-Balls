using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{

	Rigidbody2D rb;

	public int playerNumber;
	public float acceleration = 1f;
	public float maxSpeed = 10f;
	public float wJumpTimeLimit = 0.1f;
	public float jumpPower = 20f;
	public float gravityMultiplier = 2.5f;
	public float turnSpeed = 5f;
	public float wallJumpVel = 3f;
	public string leftKey;
	public string rightKey;
	public string jumpKey;
	private bool wTimerOn = false;
	private GameObject wall = null;
	private bool moveLeft;
	private bool moveRight;
	private bool moveJump;
	private bool wallJump = false;
	private float wJumpTimer;


	private void Awake()
	{
		rb = gameObject.GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void Update()
	{
		moveJump = Input.GetKey(jumpKey);
		moveRight = Input.GetKey(rightKey);
		moveLeft = Input.GetKey(leftKey);

		if (Input.GetKey("escape"))
			PlaySessionManager.ins.LoadScene("MainMenu");

		if (wallJump)
		{

			if (wTimerOn)
			{
				wJumpTimer -= Time.deltaTime; 
			}
			wallJump = (wJumpTimer <= 0 ? false : true);
			
		}
	}

	void FixedUpdate()
	{
		if (moveLeft)
		{
			if (rb.velocity.x > -maxSpeed)
				rb.AddForce(Vector2.left * acceleration * Time.fixedDeltaTime * (rb.velocity.x > 0 ? turnSpeed : 1));
		}
		if (moveRight)
		{
			if (rb.velocity.x < maxSpeed)
				rb.AddForce(Vector2.right * acceleration * Time.fixedDeltaTime * (rb.velocity.x < 0 ? turnSpeed : 1));
		}
		if (moveJump && (rb.velocity.y == 0 || PlayerCollision.instance.inCollision))
		{
			rb.AddForce(Vector2.up * jumpPower);
			PlayerCollision.instance.inCollision = false;
		}
		else if (moveJump && wallJump)
		{
			Debug.Log("Wall Jump Applied");
			if (wall != null)
			{
				Debug.Log("Wall Exists");
				wallJump = false;
				Vector2 displacement = wall.transform.position - transform.position;
				// displacement.Normalize();
				Debug.Log(displacement.x.ToString());
				rb.velocity = (Vector2.right * (-displacement.x / Mathf.Sqrt(displacement.x * displacement.x) )
					* wallJumpVel) + (Vector2.up * wallJumpVel); 
			}
		}
		if (rb.velocity.y > 9)
		{
			rb.velocity = Vector2.up * 9 + Vector2.right * rb.velocity.x;
		}
		else if (rb.velocity.y < 0)
		{

			rb.AddForce(Vector2.up * Physics2D.gravity.y * (gravityMultiplier - 1));
		}

		if (rb.position.y < -5)
		{
			if (playerNumber == 1)
				PlaySessionManager.ins.RoundOver(2);
			else if (playerNumber == 2)
				PlaySessionManager.ins.RoundOver(1);
		}

	}

	public void HitWall(GameObject _wall)
	{
		Debug.Log("Hit Wall");
		wallJump = true;
		wJumpTimer = wJumpTimeLimit;
		wall = _wall;
		wTimerOn = false;
	}

	public void startTimer()
	{
		wTimerOn = true;
	}




}
