﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScript : MonoBehaviour {

	public void LoadScene(string sceneName)
	{
		PlaySessionManager.ins.LoadScene(sceneName);
	}
}