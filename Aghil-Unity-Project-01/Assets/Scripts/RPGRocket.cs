using UnityEngine;
using System.Collections;

public class RPGRocket : MonoBehaviour {
	public float Speed;
	// Use this for initialization

	// Update is called once per frame
	void Update () {

		transform.Translate (Vector3.right * Time.deltaTime * Speed);

	
}
}
