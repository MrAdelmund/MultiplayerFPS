using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
public class scope : NetworkBehaviour {

	public Camera MainCamera;
	public GameObject Scope;

	float defsize;
	float defsens;
	public float camSize = 10;

	// Use this for initialization
	public void Start()
	{
		defsize = MainCamera.fieldOfView;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButton (1)) {
			Scope.SetActive (true);
			MainCamera.fieldOfView = camSize;
		} else {
			Scope.SetActive (false);
			MainCamera.fieldOfView = defsize;
		}
	}
}
