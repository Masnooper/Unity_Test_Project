using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;
public class GameManager : MonoBehaviour {
	public GameObject MG42Cam;
	public GameObject MainCam;
	public float minMovement = 20.0f;
	public bool sendUpMessage = true;
	public bool sendDownMessage = true;
	public bool sendLeftMessage = true;
	public bool sendRightMessage = true;
	public GameObject MessageTarget = null;
	public GameObject Joystick;
	public GameObject fireBTN;
	public GameObject MG42Body;
	public GameObject NestImage;
	public GameObject MG42Object;


	private Vector3 MG42Default;
	private Vector2 StartPos;
	private int SwipeID = -1;
	void Start(){
		MG42Default = MG42Body.transform.eulerAngles;
		MG42Body.GetComponent<TouchControl> ().enabled = false;
		Joystick.SetActive (false);
		fireBTN.SetActive (false);
	}
	void Update ()
	{
		print (MG42Body.transform.localEulerAngles);
		if (MessageTarget == null)
			MessageTarget = gameObject;
		foreach (var T in Input.touches)
		{
			var P = T.position;
			if (T.phase == TouchPhase.Began && SwipeID == -1)
			{
				SwipeID = T.fingerId;
				StartPos = P;
			}
			else if (T.fingerId == SwipeID)
			{
				var delta = P - StartPos;
				if (T.phase == TouchPhase.Moved && delta.magnitude > minMovement)
				{
					SwipeID = -1;
					if (Mathf.Abs(delta.x) > Mathf.Abs(delta.y))
					{
						if (sendRightMessage && delta.x > 0)
							MessageTarget.SendMessage("OnSwipeRight", SendMessageOptions.DontRequireReceiver);
						else if (sendLeftMessage && delta.x < 0)
							MessageTarget.SendMessage("OnSwipeLeft", SendMessageOptions.DontRequireReceiver);
					}
					else
					{
						if (sendUpMessage && delta.y > 0)
							MessageTarget.SendMessage("OnSwipeUp", SendMessageOptions.DontRequireReceiver);
						else if (sendDownMessage && delta.y < 0)
							MessageTarget.SendMessage("OnSwipeDown", SendMessageOptions.DontRequireReceiver);
					}
				}
				else if (T.phase == TouchPhase.Canceled || T.phase == TouchPhase.Ended)
				{
					SwipeID = -1;
					MessageTarget.SendMessage("OnTap", SendMessageOptions.DontRequireReceiver);
				}
			}
		}
	}
	void DoAim(){
		MG42Object.SetActive (true);
		MG42Body.GetComponent<TouchControl> ().enabled = true;
		MG42Cam.SetActive (true);
		NestImage.SetActive (false);
		Joystick.SetActive (true);
		fireBTN.SetActive (true);
		MainCam.SetActive (false);

	}
	void OnSwipeDown(){
		NestImage.SetActive (true);
		MG42Object.SetActive (false);
		MG42Body.GetComponent<TouchControl> ().enabled = false;
		Joystick.SetActive (false);
		fireBTN.SetActive (false);
		MG42Body.transform.localRotation= Quaternion.Euler(MG42Default);
		MG42Cam.SetActive (false);
		MainCam.SetActive (true);
	}
	
}
