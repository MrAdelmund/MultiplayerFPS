using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class matchSettings : NetworkBehaviour {
	//this script will load the match settings
	//and apply them to other objects
	[SyncVar]
	public int scoreToWin;

	[SyncVar]
	public string sceneToLoad;


	void Start () {
		Load ();
	}

	[Server]
	public void Load()
	{
		if (File.Exists (Application.dataPath + "/matchData.dat")) {
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream file = File.Open (Application.dataPath + "/matchData.dat", FileMode.Open);
			Infoo info = (Infoo)bf.Deserialize (file);
			file.Close ();
			scoreToWin = info.scoreToWin;
			sceneToLoad = info.levelToLoad;
			Debug.Log ("Loaded");
		}
	}


	void Update()
	{
		if (isServer && Input.GetKey (KeyCode.Return)) {
			Save ();
		}

		if (SceneManager.GetSceneByName ("LoadData").isLoaded || Input.GetKey(KeyCode.Insert)) {
			loadScene ();
		}
	}



	public void loadScene()
	{
		SceneManager.LoadScene (sceneToLoad);
	}

	[Server]
	public void Save()
	{
		BinaryFormatter bf = new BinaryFormatter ();
		FileStream file = File.Create (Application.dataPath + "/matchData.dat");
		Infoo inf = new Infoo ();
		if (gameObject.GetComponent<Canvas>() != null) {
			inf.scoreToWin = int.Parse(transform.GetComponentInChildren<InputField> ().text);
			inf.levelToLoad = transform.GetComponentInChildren<Dropdown> ().captionText.text;
		}
		bf.Serialize (file, inf);
		Debug.Log ("Saved");
		file.Close ();
	}
		
	public void HostSave()
	{
		BinaryFormatter bf = new BinaryFormatter ();
		FileStream file = File.Create (Application.dataPath + "/matchData.dat");
		Infoo inf = new Infoo ();
		if (gameObject.GetComponent<Canvas>() != null) {
			inf.scoreToWin = int.Parse(transform.GetComponentInChildren<InputField> ().text);
			inf.levelToLoad = transform.GetComponentInChildren<Dropdown> ().captionText.text;
		}
		bf.Serialize (file, inf);
		Debug.Log ("Saved");
		file.Close ();
	}


}

[Serializable]
public class Infoo
{
	//the score needed to end the match
	public int scoreToWin;

	//the level name to load
	public string levelToLoad;
}



