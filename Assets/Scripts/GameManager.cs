using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public float restartDelay = 1f;

	public void EndGame(int player)
	{
		if (player == 1)
			Debug.Log("Player 2 wins!");
		else if (player == 2)
			Debug.Log("Player 1 Wins!");
		else
			Debug.Log("A Mysterious Player steals the Match!..");

		Debug.Log("Restarting... Please wait patiently :)");

		Invoke("Restart", restartDelay);
	}

	void Restart()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
}
