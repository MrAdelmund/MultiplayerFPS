using UnityEngine;
using Prototype.NetworkLobby;
using System.Collections;
using UnityEngine.Networking;
using UnityStandardAssets.Characters.FirstPerson;

public class NetworkLobbyHook : LobbyHook 
{
    public override void OnLobbyServerSceneLoadedForPlayer(NetworkManager manager, GameObject lobbyPlayer, GameObject gamePlayer)
    {
        LobbyPlayer lobby = lobbyPlayer.GetComponent<LobbyPlayer>();
        FirstPersonController spaceship = gamePlayer.GetComponent<FirstPersonController>();

        spaceship.name = lobby.name;
		spaceship.gameObject.transform.GetChild(0).gameObject.GetComponent<MeshRenderer>().material.color = lobby.playerColor;
		if (spaceship.GetComponent<spawn> ().local) {
			
		}
    }
}
