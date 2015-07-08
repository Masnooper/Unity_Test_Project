using UnityEngine;
using System.Collections;

public class TapToAim : MonoBehaviour {
	public GameObject GameManager;
	// Use this for initialization
	void OnMouseDown () {
		GameManager.SendMessage ("DoAim",SendMessageOptions.DontRequireReceiver);
	}
	

}
