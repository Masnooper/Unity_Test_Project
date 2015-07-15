using UnityEngine;
using System.Collections;

public class Fadein : MonoBehaviour {

	public Texture2D bg;
	public float alpha= 1;
	public float AlphaTo= 0;
	public float Speed;
	private bool StartFade;
	public GameObject GameManager;
	// Use this for initialization
	void Start () {
		if(AlphaTo>0){
			alpha = 0;
		}
	}
	
	void FadeIn(){
		AlphaTo = 0;
		alpha = 1;
	}
	
	void FadeOut(){
		AlphaTo = 1;
		alpha = 0;
	}

	void OnEnable() {
		StartFade=true;
	}
	void OnDisable() {
		FadeIn();
		StartFade=false;
	}
	
	void OnGUI () {
		if(StartFade){
			alpha += (AlphaTo - alpha)/100*Speed*Time.deltaTime;
			
			GUI.color = new Color(1,1,1,alpha);
			GUI.DrawTexture(new Rect(0,0,Screen.width,Screen.height),bg);
			if (alpha<0.02f){
				StartFade=false;
				FadeIn();

				}
			
		}
}

}
