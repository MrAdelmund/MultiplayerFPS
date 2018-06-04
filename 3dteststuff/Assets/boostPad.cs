using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boostPad : MonoBehaviour {

	public Vector3 boostSpeed;

	void OnCollisionEnter(Collision Coll)
	{
		Coll.transform.Translate (boostSpeed);
		Debug.Log ("boost");
	}
}
