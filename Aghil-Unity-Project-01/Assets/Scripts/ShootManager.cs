﻿using UnityEngine;
using System.Collections;

public class ShootManager : MonoBehaviour {

	public Transform MG42Body;
	public Animator MG42Animator;
	private float MG42Stray;
	public float MG42MaxStray;
	public Transform ShootPointMG42;
	private bool StartShoot;
	public float FireRate;
	public float RecoilPower;
	public GameObject MuzzleFlash;
	private Quaternion ShootpointorginRot;

	public Animator RPGAnimator;
	public GameObject RPGMuzzelFlash;
	public Transform RPGShootPoint;
	public GameObject RPGLoadedRocket;
	public GameObject RPGRocket;

	public GameObject SVDObject;
	public Animator SVDAminator;
	public Camera ScopeCamSVD;
	private bool IsRPGReady;
	private bool IsSVDReady;

	// Use this for initialization
	void Start () {
	
		MG42Animator.StopPlayback ();
		ShootpointorginRot = ShootPointMG42.rotation;
	}
	
	// Update is called once per frame
	void Update () {
	if (StartShoot)
			InvokeRepeating ("FireWeapon", FireRate, FireRate);
		else 
			ShootPointMG42.rotation = ShootpointorginRot;


	}

	void FireWeapon()
		
	{
			
			MG42Animator.SetBool("Shoot",true);
			MuzzleFlash.SetActive (true);
			var randomNumberX = Random.Range(-MG42Stray, MG42Stray);
			var randomNumberY = Random.Range(-MG42Stray, MG42Stray);
			var randomNumberZ = Random.Range(-MG42Stray, MG42Stray);
			RaycastHit hit;
			ShootPointMG42.Rotate(randomNumberX, randomNumberY, randomNumberZ);
			Vector3 FWD = ShootPointMG42.TransformDirection(Vector3.right);
			if (Physics.Raycast (ShootPointMG42.position, FWD, out hit)){
				Debug.DrawLine(ShootPointMG42.position, hit.point,Color.black,3);
				if(hit.collider.tag=="Target"){
					hit.transform.SendMessage ("TakeDamage",true,SendMessageOptions.DontRequireReceiver);}
			}
			//GameObject YourProjectileClone =(GameObject)Instantiate(MG42Bullet,ShootPointMG42.position,ShootPointMG42.rotation); // instantiate projectile
			//YourProjectileClone.transform.Rotate(randomNumberX, randomNumberY, randomNumberZ);

		if (MG42Stray < MG42MaxStray)
			MG42Stray += 0.01f;


		StartShoot = true;
		CancelInvoke ("FireWeapon");
}
	void StopFire(){
		MG42Stray = 0f;
		MuzzleFlash.SetActive (false);
		MG42Animator.SetBool("Shoot",false);
		StartShoot = false;
		CancelInvoke ("FireWeapon");
	}
	void RPGfire(){
		if (IsRPGReady) {
			IsRPGReady = false;
			RPGLoadedRocket.SetActive (false);
			RPGMuzzelFlash.SetActive (true);
			RPGAnimator.SetTrigger ("Fire");
			Instantiate (RPGRocket, RPGShootPoint.position, RPGShootPoint.rotation);
		}

	}
	 void RPGReady(){
		IsRPGReady = true;

	}
	void SVDReady(){
		IsSVDReady = true;
		
	}
	void SVDFire(){
		if (IsSVDReady) {
			SVDAminator.SetTrigger ("Fire");
			Ray ray = ScopeCamSVD.ViewportPointToRay (new Vector3(0.5f,0.5f,0));   
			RaycastHit hit;
			Physics.Raycast (ray,out hit);
			print (hit.collider.name + " hit");
		}
	}
}