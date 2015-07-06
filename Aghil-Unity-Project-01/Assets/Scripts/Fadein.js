
var bg:Texture2D;
var alpha:float = 1;
var AlphaTo:float = 0;

function Start(){
	if(AlphaTo>0){
		alpha = 0;
	}
}
function FadeIn(){
	AlphaTo = 0;
	alpha = 1;
}

function FadeOut(){
	AlphaTo = 1;
	alpha = 0;
}

function OnGUI () {
	if(bg){
	alpha += (AlphaTo - alpha)/100;
	
	GUI.color = new Color(1,1,1,alpha);
	GUI.DrawTexture(Rect(0,0,Screen.width,Screen.height),bg);
	
	}
}