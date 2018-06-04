using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ladder : MonoBehaviour {

	public float distance;
	void OnCollisionEnter(Collision Coll)
	{
		Coll.transform.Translate (new Vector3 (0, distance, 0));
	}
}
