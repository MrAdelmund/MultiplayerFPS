using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class checkPlayscene : MonoBehaviour {

    public string level;
    public Text ui;
    public NetworkLobbyManager lobby;
    public string[] scenes;

    public void Update()
    {
        if(ui.text == "Waterland")
        {
            lobby.playScene = scenes[0];
        }
        else if(ui.text == "Dungeon")
        {
            lobby.playScene = scenes[1];
        }
        else if(ui.text == "Forest")
        {
            lobby.playScene = scenes[2];
        } 
        else if(ui.text == "Kyler Map")
        {
            lobby.playScene = scenes[3];
        }
        else if(ui.text == "Damon Map")
        {
            lobby.playScene = scenes[4];
        }
    }




}
