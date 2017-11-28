using UnityEngine;
using UnityEngine.SceneManagement;

public class PlaySessionManager : MonoBehaviour {

	public static PlaySessionManager ins;

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
	}

	public void RoundOver(int playerNumber)
	{
		Debug.Log("Player" + playerNumber + "has Lost");
		Invoke("Restart", 1f);
	}

	private void Restart()
	{
		
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	public void LoadScene(string sceneName)
	{
		
		SceneManager.LoadScene(sceneName);
	}

	
}
