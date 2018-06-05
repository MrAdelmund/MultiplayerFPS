using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamPoints : MonoBehaviour {

    // Use this for initialization
    public int[] teamPoints;
	void Start () {
        teamPoints = new int[6];
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void TeamPoint(int teamNum)
    {
        teamPoints[teamNum]++;
    }
}
