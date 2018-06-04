using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class weaponSelect : MonoBehaviour {

	public string Weapon;

	public string Name;
	public float FireRate;
	public float Range;
	public Transform GunEnd;
	// Use this for initialization
	void Start ()
	{
		Sniper defaultWeapon = new Sniper ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	public void WeaponSelect()
	{
		switch (Weapon) {
		case ("Sniper"):

			Sniper newSniper = new Sniper (Name, FireRate, Range, GunEnd);
			break;
		case ("Rifle"):
			Rifle newRifle = new Rifle (Name, FireRate, Range, GunEnd);
			break;
		case ("SMG"):
			SMG newSMG = new SMG (Name, FireRate, Range, GunEnd);
			break;
		case ("Shotgun"):
			Shotgun newGun = new Shotgun (Name, FireRate, Range, GunEnd);
			break;
		}
	}


}

public class BaseWeapon
{
	public string name;
	public float fireRate;
	public float range;
	public Transform gunEnd;
}


public class Sniper : BaseWeapon
{
	public Sniper()
	{	
		name = "Sniper";
		fireRate = 0.75f;
		range = 200f;
		gunEnd = GameObject.FindWithTag ("Player").transform.Find ("Emitter").transform;
	}
	public Sniper(string newName, float newFireRate, float newRange, Transform newEnd)
	{
		newName = name;
		newFireRate = fireRate;
		newRange = range;
		newEnd = gunEnd;
	}
}

public class Rifle : BaseWeapon
{
	public Rifle()
	{	
		name = "Rifle";
		fireRate = 0.5f;
		range = 100f;
		gunEnd = GameObject.FindWithTag ("Player").transform.Find ("Emitter").transform;
	}
	public Rifle(string newName, float newFireRate, float newRange, Transform newEnd)
	{
		newName = name;
		newFireRate = fireRate;
		newRange = range;
		newEnd = gunEnd;
	}
}

public class SMG : BaseWeapon
{
	public SMG()
	{	
		name = "SMG";
		fireRate = 0.2f;
		range = 50f;
		gunEnd = GameObject.FindWithTag ("Player").transform.Find ("Emitter").transform;
	}
	public SMG(string newName, float newFireRate, float newRange, Transform newEnd)
	{
		newName = name;
		newFireRate = fireRate;
		newRange = range;
		newEnd = gunEnd;
	}
}

public class Shotgun : BaseWeapon
{
	public Shotgun()
	{	
		name = "Shotgun";
		fireRate = 1f;
		range = 50f;
		gunEnd = GameObject.FindWithTag ("Player").transform.Find ("Emitter").transform;
	}
	public Shotgun(string newName, float newFireRate, float newRange, Transform newEnd)
	{
		newName = name;
		newFireRate = fireRate;
		newRange = range;
		newEnd = gunEnd;
	}
}
