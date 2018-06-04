using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.Networking;


public class respawnIn : NetworkBehaviour {

	public float timeUntil;
	float timer = 0;
	public Camera spn;
//	public FirstPersonController Gam;
	private bool me = false;

	// Use this for initialization
	public override void OnStartLocalPlayer()
	{
		me = true;
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if (timer >= timeUntil)
		{
			if (!me) {
				spn.enabled = true;
			}
		//	Gam.enabled = true;
		//	spn.Act ();
		}
	}
}
