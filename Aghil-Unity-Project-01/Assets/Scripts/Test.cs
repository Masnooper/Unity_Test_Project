using UnityEngine;
using System.Collections;

public class Test : MonoBehaviour {

	public Camera ZoomCam;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		Ray ray = ZoomCam.ViewportPointToRay (new Vector3(0.5f,0.5f,0));   
		RaycastHit hit;
		Physics.Raycast (ray,out hit);
		Debug.DrawLine(ray.origin, hit.point,Color.black);
		print (hit.collider.name + " hit");
	}
}
