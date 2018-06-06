using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portals : MonoBehaviour {

    public GameObject red;
    public GameObject blue;
    public bool isRed;
    public Vector3 offset;


    public void OnTriggerEnter(Collider other)
    {
        Vector3 pos;
        if (isRed)
        {
            pos = blue.transform.position;
        }
        else
        {
            pos = red.transform.position;
        }
        pos = new Vector3(pos.x + offset.x, pos.y + offset.y, pos.z + offset.z);
        other.transform.SetPositionAndRotation(pos, Quaternion.identity);
    }




}
