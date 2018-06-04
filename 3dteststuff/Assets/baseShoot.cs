using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class baseShoot : NetworkBehaviour {

	public GameObject bullet;
	public Transform targetAim;
	public float bulletSpeed;
	public int ammoMax;
	public float bulletLifetime;
	public float coolDown;
	float timer = 0;
	int currentAmmo;


	// Use this for initialization
	void Start () {
		currentAmmo = ammoMax;
	}
	
	// Update is called once per frame
	void Update ()
	{
		timer += Time.deltaTime; 
		if (timer > coolDown) {
			if (Input.GetMouseButton (0)) {
				currentAmmo--;
				Shoot ();
				timer = 0;
			}
		}
	}

	void Shoot()
	{
		GameObject proj = bullet;

		//create the shoot direction, which is calculated by mousePosition - playerPosition
		Vector2 shootDirection = new Vector3 (targetAim.position.x - transform.position.x, targetAim.position.y- transform.position.y, targetAim.position.z - transform.position.z);
		//create the bullet object

		//reduce the length of the direction to 1, so it is always the same regardless of how far away
		//the mouse is from the player. 
		shootDirection.Normalize();

		Vector3 spawnPosition = transform.position;
		spawnPosition.x += shootDirection.x * 0.2f;
		spawnPosition.y += shootDirection.y * 0.2f;
		GameObject bulle = (GameObject)Instantiate (proj, spawnPosition, Quaternion.identity);
		//apply the velocity in the shoot direction
		bulle.GetComponent<Rigidbody> ().velocity = shootDirection * bulletSpeed;
		Destroy (bulle, bulletLifetime);

	}

}
