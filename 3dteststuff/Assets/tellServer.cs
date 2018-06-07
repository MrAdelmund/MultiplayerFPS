using Prototype.NetworkLobby;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class tellServer : NetworkBehaviour {

	public NetworkStartPosition[] spawnPoints;
    public int hp = 3;
    public int startHP = 3;
    public Color teamColor;
    public int teamNumber;
    public AudioClip sound;

    public int kills;

	public bool hit = false;

	void Start()
	{
        hp = startHP;
		spawnPoints = FindObjectsOfType<NetworkStartPosition> ();
	}

	void Update()
	{
        GetComponentInChildren<Slider>().value = hp;
	}

	[Command]
	public void CmdHitEnemy(GameObject Enemy)
	{
		if (!isServer) {
			//Enemy.GetComponent<ShootableBox> ().hit = true;
			// Set the spawn point to origin as a default value
			Vector3 spawnPoint = Vector3.zero;

			// If there is a spawn point array and the array is not empty, pick one at random
			if (spawnPoints != null && spawnPoints.Length > 0) {
				spawnPoint = spawnPoints [Random.Range (0, spawnPoints.Length)].transform.position;
				spawnPoint = new Vector3 (spawnPoint.x, spawnPoint.y + 1, spawnPoint.z);
			}

            // Set the player’s position to the chosen spawn point
            if (Enemy.GetComponent<tellServer>().teamColor != teamColor)
            {
                Debug.Log("enemy color hit!");
                Enemy.GetComponent<tellServer>().hp = Enemy.GetComponent<tellServer>().hp - 1;
                GetComponent<AudioSource>().PlayOneShot(sound);
                Debug.Log("New HP: " + Enemy.GetComponent<tellServer>().hp);
                if (Enemy.GetComponent<tellServer>().hp <= 0)
                {
                    Debug.Log(System.Array.IndexOf(LobbyPlayer.Colors, teamColor));
                    if(teamColor == Color.blue)
                    {
                        Debug.LogError("foo");
                        GetComponent<scoreboard1>().team1Kills++;
                    }
                   else  if (teamColor == Color.red)
                    {
                        Debug.LogError("foo");
                        GetComponent<scoreboard1>().team2Kills++;
                    }
                    else if (teamColor == Color.cyan)
                    {
                        GetComponent<scoreboard1>().team3Kills++;
                    }
                    else if (teamColor == Color.yellow)
                    {
                        GetComponent<scoreboard1>().team4Kills++;
                    }
                    else if (teamColor == Color.green)
                    {
                        GetComponent<scoreboard1>().team5Kills++;
                    }
                    else if (teamColor == Color.magenta)
                    {
                        GetComponent<scoreboard1>().team6Kills++;
                    }
                    Enemy.GetComponent<tellServer>().hp = startHP;
                    Enemy.transform.position = spawnPoint;
                }
            }
		} else {
			RpcCalledToClient (Enemy);
		}
	}

	[ClientRpc]
	public void RpcCalledToClient(GameObject Enemy)
	{
		Vector3 spawnPoint = Vector3.zero;

		// If there is a spawn point array and the array is not empty, pick one at random
		if (spawnPoints != null && spawnPoints.Length > 0) {
			spawnPoint = spawnPoints [Random.Range (0, spawnPoints.Length)].transform.position;
			spawnPoint = new Vector3 (spawnPoint.x, spawnPoint.y + 1, spawnPoint.z);
		}
        if (Enemy.GetComponent<tellServer>().teamColor != teamColor)
        {
            Debug.Log("enemy color hit!");
            Enemy.GetComponent<tellServer>().hp = Enemy.GetComponent<tellServer>().hp - 1;
            Debug.Log("New HP: " + Enemy.GetComponent<tellServer>().hp);
            if (Enemy.GetComponent<tellServer>().hp <= 0)
            {
                Debug.Log(System.Array.IndexOf(LobbyPlayer.Colors, teamColor));
                if (teamColor == Color.blue)
                {
                    Debug.LogError("foo");
                    GetComponent<scoreboard1>().team1Kills++;
                }
                else if (teamColor == Color.red)
                {
                    Debug.LogError("foo");
                    GetComponent<scoreboard1>().team2Kills++;
                }
                else if (teamColor == Color.cyan)
                {
                    GetComponent<scoreboard1>().team3Kills++;
                }
                else if (teamColor == Color.yellow)
                {
                    GetComponent<scoreboard1>().team4Kills++;
                }
                else if (teamColor == Color.green)
                {
                    GetComponent<scoreboard1>().team5Kills++;
                }
                else if (teamColor == Color.magenta)
                {
                    GetComponent<scoreboard1>().team6Kills++;
                }
                Enemy.GetComponent<tellServer>().hp = startHP;
                Enemy.transform.position = spawnPoint;
            }
        }
        // Set the player’s position to the chosen spawn point
        //Enemy.transform.position = spawnPoint;
	}

}