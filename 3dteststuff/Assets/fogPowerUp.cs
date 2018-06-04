using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Networking;

public class fogPowerUp : MonoBehaviour {

	public bool poweredUp = false;
	public bool isPowerup = false;
	public float powerUpTimer = 15f;
	float currentTime;

	
	// Update is called once per frame
	void Update (){
		if (!poweredUp)
			return;
		currentTime += Time.deltaTime;
		if (currentTime >= powerUpTimer) {
			RenderSettings.fog = false;
			currentTime = 0;
			poweredUp = false;
			RenderSettings.fog = true;}}					
	

	void BeginPowerUp(){
		poweredUp = true;
		RenderSettings.fog = false;}
	


	void OnTriggerEnter(Collider Coll)
	{
		Debug.Log ("Collision");
		if (Coll.gameObject.tag == "Player") {
			Coll.gameObject.GetComponent<fogPowerUp> ().BeginPowerUp ();
			Destroy (gameObject);
	}}
	
}
