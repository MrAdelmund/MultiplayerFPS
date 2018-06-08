using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.Networking;
using UnityEngine.UI;

public class scoreboard1 : NetworkBehaviour {

    public GameObject[] players;
    public List<int> scores = new List<int>();
    bool active;

    [SyncVar]
    public int highst;

    [SyncVar]
    public string highestName;

    [SyncVar]
    public int team1Kills;
    [SyncVar]
    public int team2Kills;
    [SyncVar]
    public int team3Kills;
    [SyncVar]
    public int team4Kills;
    [SyncVar]
    public int team5Kills;
    [SyncVar]
    public int team6Kills;

    public Text myScore;
    public Text highScore;
    public int scoreLimit;
    public int maxScore;

    public void Awake()
    {
        StartCoroutine(GetPlayers());
        scoreLimit = PlayerPrefs.GetInt("scoreLimit");
    }

    // Update is called once per frame
    void Update () {

        if (!active) {
            return;
                }

        if(highst >= PlayerPrefs.GetInt("scoreLimit"))
        {
            if (!isServer)
            {
                return;
            }
            GetComponent<displayScore>().RpcWin(highestName);
            enabled = false;
        }

        scores = new List<int>();
        scores.Add(team1Kills);
        scores.Add(team2Kills);
        scores.Add(team3Kills);
        scores.Add(team4Kills);
        scores.Add(team5Kills);
        scores.Add(team6Kills);

        int max = scores.Max();
        int personalScore = GetComponent<tellServer>().kills;

        if(personalScore > max)
        {
            highst = personalScore;
            highestName = PlayerPrefs.GetString("name");
            updateScores();
        }
        change(personalScore, max);
	}

    public IEnumerator GetPlayers()
    {
        Debug.Log("foo");
        yield return new WaitForSeconds(3f);
        Debug.Log("foo");
        players = GameObject.FindGameObjectsWithTag("Player");
        active = true;
    }

    public void change(int personal, int highest)
    {
        highScore.text = "Highest Score: " + highestName + " : " + highest;
        myScore.text = "Personal Score: " + gameObject.name + " : " + personal;
    }

    public void updateScores()
    {
        team1Kills = PlayerPrefs.GetInt("team1");
        team2Kills = PlayerPrefs.GetInt("team2");
        team3Kills = PlayerPrefs.GetInt("team3");
        team4Kills = PlayerPrefs.GetInt("team4");
        team5Kills = PlayerPrefs.GetInt("team5");
        team6Kills = PlayerPrefs.GetInt("team6");
        GameObject[] GA = GameObject.FindGameObjectsWithTag("Player");
        for(int i = 0; i < GA.Length; i++)
        {
            GA[i].GetComponent<scoreboard1>().team1Kills = team1Kills;
            GA[i].GetComponent<scoreboard1>().team2Kills = team2Kills;
            GA[i].GetComponent<scoreboard1>().team3Kills = team3Kills;
            GA[i].GetComponent<scoreboard1>().team4Kills = team4Kills;
            GA[i].GetComponent<scoreboard1>().team5Kills = team5Kills;
            GA[i].GetComponent<scoreboard1>().team6Kills = team6Kills;
            GA[i].GetComponent<scoreboard1>().highestName = highestName;
        }
    }




}
