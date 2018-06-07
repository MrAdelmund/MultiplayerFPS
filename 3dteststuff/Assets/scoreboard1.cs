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

    public int maxScore;

    public void Awake()
    {
        StartCoroutine(GetPlayers());
    }

    // Update is called once per frame
    void Update () {

        if (!active) {
            return;
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

}
