using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour {

	public float BulletSpeed;

	void Start(){
		Destroy (gameObject, 6);
	}
	void Update () {
		transform.Translate (Vector3.right * BulletSpeed * Time.deltaTime);
	}
}
