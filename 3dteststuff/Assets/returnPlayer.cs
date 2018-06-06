using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class returnPlayer : NetworkBehaviour
{
	public bool isLocal()
    {
        if (isLocalPlayer)
        {
            return true;
        }
        else
            return false;
    }
}
