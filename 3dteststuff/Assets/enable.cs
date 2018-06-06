using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enable : MonoBehaviour {

    public GameObject obj;
	
	// Update is called once per frame
	void Update () {
        obj.SetActive(true);
	}
}
