using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPosistionFinder : MonoBehaviour {


	public static Transform[] startPos;


	private void Awake()
	{
		startPos = new Transform[transform.childCount];

		for (int i = 0; i < transform.childCount; i++)
		{
			startPos[i] = transform.GetChild(i);
		}
	}
}
