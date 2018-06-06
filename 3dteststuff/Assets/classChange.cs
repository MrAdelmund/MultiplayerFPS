using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityStandardAssets.Characters.FirstPerson;

public class classChange : NetworkBehaviour {

    public bool isPaused;
    public FirstPersonController Sniper;
    public FirstPersonController Duel;
    public FirstPersonController Ninja;
    public FirstPersonController Rifle;
    public FirstPersonController playerFPS;
    public Canvas buttons;
    public GameObject SniperObj;
    public GameObject DuelObj;
    public GameObject NinjaObj;
    public GameObject RifleObj;


     void Start()
    {
        if (!isLocalPlayer)
            enabled = false;
    }
    // Update is called once per frame
    void Update ()
    {
        if (isPaused)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                isPaused = false;
                buttons.enabled = false;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                CmdClassChange(1);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                CmdClassChange(2);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                CmdClassChange(3);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                CmdClassChange(4);
            }
        }
      else if (Input.GetKeyDown(KeyCode.Return))
        {
            buttons.enabled = true;
            isPaused = true;
        }
       
	}

    [Command]
    void CmdClassChange(int _class)
    {
        switch (_class)
        {
            case 1:
                SniperObj.GetComponentInChildren<RayCastShootComplete>().enabled = true;
                SniperObj.GetComponentInChildren<RayViewerComplete>().enabled = true;
                playerFPS = Sniper;
                SniperObj.SetActive(true);
                RifleObj.SetActive(false);
                DuelObj.SetActive(false);
                NinjaObj.SetActive(false);
                break;
            case 2:
                DuelObj.GetComponentInChildren<RayCastShootComplete>().enabled = true;
                DuelObj.GetComponentInChildren<RayViewerComplete>().enabled = true;
                playerFPS = Duel;
                SniperObj.SetActive(false);
                RifleObj.SetActive(false);
                DuelObj.SetActive(true);
                NinjaObj.SetActive(false);
                break;
            case 3:
                NinjaObj.GetComponentInChildren<RayCastShootComplete>().enabled = true;
                NinjaObj.GetComponentInChildren<RayViewerComplete>().enabled = true;
                playerFPS = Ninja;
                SniperObj.SetActive(false);
                RifleObj.SetActive(false);
                DuelObj.SetActive(false);
                NinjaObj.SetActive(true);
                break;
            case 4:
                RifleObj.GetComponentInChildren<RayCastShootComplete>().enabled = true;
                RifleObj.GetComponentInChildren<RayViewerComplete>().enabled = true;
                playerFPS = Rifle;
                SniperObj.SetActive(false);
                RifleObj.SetActive(true);
                DuelObj.SetActive(false);
                NinjaObj.SetActive(false);
                break;
        }
        RpcSend(_class);
        GetComponent<tellServer>().RpcCalledToClient(gameObject);
              
       

    }

    [ClientRpc]
    void RpcSend(int _class)
    {
        switch (_class)
        {
            case 1:
                playerFPS = Sniper;
                SniperObj.SetActive(true);
                RifleObj.SetActive(false);
                DuelObj.SetActive(false);
                NinjaObj.SetActive(false);
                break;
            case 2:
                playerFPS = Duel;
                SniperObj.SetActive(false);
                RifleObj.SetActive(false);
                DuelObj.SetActive(true);
                NinjaObj.SetActive(false);
                break;
            case 3:
                playerFPS = Ninja;
                SniperObj.SetActive(false);
                RifleObj.SetActive(false);
                DuelObj.SetActive(false);
                NinjaObj.SetActive(true);
                break;
            case 4:
                playerFPS = Rifle;
                SniperObj.SetActive(false);
                RifleObj.SetActive(true);
                DuelObj.SetActive(false);
                NinjaObj.SetActive(false);
                break;
        }
    }
    

}
