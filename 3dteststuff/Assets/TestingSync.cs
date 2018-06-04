using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class TestingSync : NetworkBehaviour {

	// Use this for initialization
	[SyncVar]
	public int hp = 100;
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (!isServer) {
			hp -= 1;
		}
	}
}
