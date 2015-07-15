using UnityEngine;
using System.Collections;

public class SVDReady : MonoBehaviour {

	public GameObject ShootManager;
	public void ReadySVD () {
		ShootManager.SendMessage("SVDReady", SendMessageOptions.DontRequireReceiver);
	}

}
