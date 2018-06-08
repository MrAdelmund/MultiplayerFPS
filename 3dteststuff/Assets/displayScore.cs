using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;

public class displayScore : NetworkBehaviour {
    public GameObject lobbyObj;
    public Canvas victory;
    public Text text;

    private void Start()
    {
        lobbyObj = GameObject.Find("LobbyManager");
    }

    [ClientRpc]
    public void RpcWin(string name)
    {
        
        victory.enabled = true;
        text.text = "" + name + " wins!";
        StartCoroutine(Wait());

    }
    
    public IEnumerator Wait()
    {
        Destroy(lobbyObj);
        Debug.Log("ending");
        yield return new WaitForSeconds(3f);
        Debug.Log("end");
        SceneManager.LoadScene("debug2");
       // Application.Quit();
    }
}
