using UnityEngine;
using System.Collections;

public class ShootManager : MonoBehaviour {

	public Animator MG42Animator;
	public GameObject MG42Bullet;
	public float MG42Stray;
	public Transform ShootPointMG42;
	private float NextShot;
	private bool StartShoot;
	public float FireRate;
	// Use this for initialization
	void Start () {
	
		MG42Animator.StopPlayback ();
	}
	
	// Update is called once per frame
	void Update () {
	if (StartShoot)
			InvokeRepeating ("FireWeapon", FireRate, FireRate);

	
	}

	void FireWeapon()
		
	{
		
		if(Time.time > NextShot)
			
		{

			MG42Animator.SetBool("Shoot",true);
			var randomNumberX = Random.Range(-MG42Stray, MG42Stray);
			var randomNumberY = Random.Range(-MG42Stray, MG42Stray);
			var randomNumberZ = Random.Range(-MG42Stray, MG42Stray);
			GameObject YourProjectileClone =(GameObject)Instantiate(MG42Bullet,ShootPointMG42.position,ShootPointMG42.rotation); // instantiate projectile
			YourProjectileClone.transform.Rotate(randomNumberX, randomNumberY, randomNumberZ);
			NextShot = Time.time + 0.1f;
		}
		StartShoot = true;
		CancelInvoke ("FireWeapon");
}
	void StopFire(){
		MG42Animator.SetBool("Shoot",false);
		StartShoot = false;
		CancelInvoke ("FireWeapon");
	}
}