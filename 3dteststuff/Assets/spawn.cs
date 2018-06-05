using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Networking.Types;
using UnityEngine.Networking.Match;
using UnityEngine.Networking.PlayerConnection;
using UnityEngine.Networking.NetworkSystem;
using UnityStandardAssets.Characters.FirstPerson;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.UI;
using Prototype.NetworkLobby;
using System.Linq;

public class spawn :NetworkBehaviour {

	public Vector3 Spawn;
	public FirstPersonController gam;
	public CharacterController Char;
	public Camera Cam;
    public string nama;
	public bool local;


    void Update()
	{
		if (!isLocalPlayer) {
			GetComponentInChildren<Camera> ().enabled = false;
			return;
		}
		if (local) {

			GetComponentInChildren<RayViewerComplete> ().enabled = true;
			GetComponentInChildren<RayCastShootComplete> ().enabled = true;
			GetComponentInChildren<Camera> ().enabled = true;
			GetComponent<FirstPersonController> ().enabled = true;
			GetComponent<CharacterController> ().enabled = true;
			GetComponent<MouseLook> ().enabled = true;
            //Color c = new Color(PlayerPrefs.GetFloat("r"), PlayerPrefs.GetFloat("g"), PlayerPrefs.GetFloat("b"));
            Material m = GetComponentInChildren<MeshRenderer>().material;
            //m.color = c;
            //GetComponent<tellServer>().teamColor = LobbyPlayer.Colors[PlayerPrefs.GetInt("teamNum")];
            //GetComponent<tellServer>().teamNumber = PlayerPrefs.GetInt("teamNum");
            NetworkLobbyPlayer[] players = GameObject.Find("LobbyManager").GetComponent<LobbyManager>().lockedPlayers;
            GameObject[] playerlist = GameObject.FindGameObjectsWithTag("Player");


        }
	}

    public override void OnStartLocalPlayer()
	{
		
		//gameObject.name = PlayerPrefs.GetString ("Name");
		Debug.Log ("it worked?");
		local = true;
        //GameObject.Find ("LoadCamera").SetActive (false);
        StartCoroutine(Colors());

    }
    IEnumerator Colors()
    {
        yield return new WaitForSeconds(1);
        GameObject[] playerlist = GameObject.FindGameObjectsWithTag("Player");
        LobbyManager lm = GameObject.Find("LobbyManager").GetComponent<LobbyManager>();
        for (int i = 0; i < playerlist.Length; i++)
        {
            playerlist[i].name = lm.lobbySlots[i].GetComponent<LobbyPlayer>().playerName;
            playerlist[i].GetComponentInChildren<MeshRenderer>().material.color = lm.lobbySlots[i].GetComponent<LobbyPlayer>().playerColor;
            playerlist[i].GetComponent<tellServer>().teamColor = lm.lobbySlots[i].GetComponent<LobbyPlayer>().playerColor;
            playerlist[i].GetComponent<tellServer>().teamNumber = System.Array.IndexOf(LobbyPlayer.Colors, playerlist[i].GetComponent<tellServer>().teamColor);
            playerlist[i].GetComponentsInChildren<Text>()[1].text = playerlist[i].name;
        }
    }


}
