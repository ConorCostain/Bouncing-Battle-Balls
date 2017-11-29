using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;

public class PlaySessionManager : MonoBehaviour {

	public static PlaySessionManager ins;
	public Color[] colourPallete;
	private static bool randomLevels = false;
	private static bool roundOver = false;
	private TMP_Text player1Text;
	private TMP_Text player2Text;
	private int player1Score = 0;
	private int player2Score = 0;

	// Singleton Pattern, OnSceneLoad Method Added
	private void Awake()
	{
		
		if(ins == null)
		{
			ins = this;
			DontDestroyOnLoad(gameObject);
			
		}
		else if(ins != this)
		{
			Destroy(gameObject);
			return;
		}
		SceneManager.sceneLoaded += OnSceneLoad;
	}

	// On Scene Load Method
	void OnSceneLoad(Scene s, LoadSceneMode lsm)
	{
		if (s.name.Contains("Level"))
		{
			// Reset Round Over bool
			roundOver = false;

			//Player Score System

			TMP_Text[] scores = FindObjectsOfType<TMP_Text>();

			if(scores[0].name == "Player1Score")
			{
				player1Text = scores[0];
				player2Text = scores[1];
			}
			else
			{
				player1Text = scores[1];
				player2Text = scores[0];
			}

			player1Text.text = player1Score.ToString();
			player2Text.text = player2Score.ToString();

			// Camera Background Colour Change
			Camera camera = FindObjectOfType<Camera>();

			Color colour = colourPallete[(int)Random.Range(0, colourPallete.Length -1)];
			camera.backgroundColor = colour;

		}
	}


	//Public Methods called by Buttons and Players
	public void LoadScene(string sceneName)
	{
		
		SceneManager.LoadScene(sceneName);
	}
	public void RoundOver(int playerNumber)
	{
		if (!roundOver)
		{
			if(playerNumber == 1)
			{
				player1Score++;
			}
			else if(playerNumber == 2)
			{
				player2Score++;
			}
			Debug.Log("Player" + playerNumber + "wins");
			roundOver = true;
			Invoke("LoadLevel", 1f); 
		}
	}


	// The Random Level System + Player Respawn
	public void LevelMixup()
	{
		randomLevels = true;
		LoadLevel();
	}
	private void LoadLevel()
	{
		if (randomLevels)
		{
			SceneManager.LoadScene(GetRandomLevel());
		}
		else
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
	private string GetRandomLevel()
	{
		int amountOfScenes = SceneManager.sceneCountInBuildSettings;
		List<string> levels = new List<string>();
		string temp;
		
		for(int i = 0; i < amountOfScenes; i++)
		{
			temp = System.IO.Path.GetFileNameWithoutExtension(UnityEngine.SceneManagement.SceneUtility.GetScenePathByBuildIndex(i));
			if (temp.Contains("Level"))
			{
				levels.Add(temp);
			}
		}

		if(levels.Count == 0)
		{
			return SceneManager.GetActiveScene().name;
		}

		int buildIndex = (int)Random.Range(0, levels.Count);

		return levels[buildIndex];
	}





	
}
