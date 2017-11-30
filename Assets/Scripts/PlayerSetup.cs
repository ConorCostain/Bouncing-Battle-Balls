using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerSetup : NetworkBehaviour {

	[SerializeField]
	Behaviour[] ComponentsToBeDisabled;
	// Use this for initialization
	void Start () {
		if (!isLocalPlayer)
		{
			foreach(Behaviour component in ComponentsToBeDisabled)
			{
				component.enabled = false;
			}
		}

		
	}
	
	
}
