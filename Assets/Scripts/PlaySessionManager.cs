using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class PlaySessionManager : MonoBehaviour {

	public static PlaySessionManager ins;
	private static bool randomLevels = false;
	private static bool roundOver = false;

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
			roundOver = false;
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
