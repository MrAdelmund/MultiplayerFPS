using Prototype.NetworkLobby;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scoreboard : MonoBehaviour {

    // Use this for initialization
    GameObject lm;
	void Start () {
        lm = GameObject.Find("LobbyManager");
	}
	
	// Update is called once per frame
	void Update () {
        int[] temp = lm.GetComponent<TeamPoints>().teamPoints;
        int teamNum = GetComponentInParent<tellServer>().teamNumber;
        int myTeamPoints = temp[teamNum];
        int theirScore = 0;
        for(int i = 0; i < temp.Length; i++)
        {
            if(temp[i] > 0 && i != teamNum)
            {
                theirScore = temp[i];
            }
        }
        string s = "";
        if(myTeamPoints > theirScore)
        {
            s = "My team: " + myTeamPoints + " \n\rTheir Team: " + theirScore;
        }
        else
        {
            s = "Their Team: " + theirScore + " \n\rMy Team: " + myTeamPoints;
        }
        GetComponentInChildren<Text>().text = "Scoreboard: \n\r" + s;
	}
}
