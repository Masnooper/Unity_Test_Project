using UnityEngine;
using System.Collections;

public class TargetScript : MonoBehaviour {

	public float health = 100;
	public float MG42DamageDone;

	void TakeDamage(){
		health -= MG42DamageDone;
		if (health < 0) {
			print ("target destroyed");
			Destroy (gameObject, 0.2f);
		}
	}
}
