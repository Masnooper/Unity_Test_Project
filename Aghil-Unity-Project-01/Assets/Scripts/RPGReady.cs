using UnityEngine;
using System.Collections;

public class RPGReady : MonoBehaviour {

	public GameObject ShootManager;
	public void ReadyRPG () {
		ShootManager.SendMessage("RPGReady", SendMessageOptions.DontRequireReceiver);
	}

}
