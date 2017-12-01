using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallJumpDetect : MonoBehaviour {

	private GameObject wall = null;

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if(collision.collider.tag == "Wall" && collision.collider.gameObject != wall)
		{
			Debug.Log("Collided with wall");
			playerMovement mov = GetComponent<playerMovement>();
			wall = collision.collider.gameObject;
			mov.HitWall(wall);
		}
		else if(collision.collider.tag == "Floor")
		{
			wall = null;
		}
	}
}
