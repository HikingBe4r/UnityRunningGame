using UnityEngine;
using System.Collections;

public enum GameState
{
	Play,
	Pause,
	End,
}

public class MenuInGame : MonoBehaviour {

	//ICON
	public Texture2D Slide;
	public Texture2D Jump;
	public Texture2D Menu;
	public Texture2D Pause;

	public Texture2D Play;
	public Texture2D Restart;
	public Texture2D Exit;
	public GUITexture PauseScreen;

	public PlayerMove PM;
	public GameState GS;

	public int time = 0;

	public int GameEnd = 0 ;

	public AudioClip BGM;
	
	// Use this for initialization
	void Start () {
		//Screen.SetResolution(1920,1080,true);
		GetComponent<AudioSource>().clip = BGM;
		GetComponent<AudioSource>().Play ();
	}
	
	// Update is called once per frame
	void Update () {

	}
	void OnGUI () {


		if (GS == GameState.Play) {

			// Slide 버튼 
			if(GUI.Button(new Rect(Screen.width/32   ,Screen.height/16*13,Screen.width/8,Screen.height/16*3), Slide)) {
				PM.Player_Status=2;
				PM.GetComponent<AudioSource>().clip = PM.Slide_BGM;
				PM.GetComponent<AudioSource>().Play();
				if(PM.Player_Status==0)
				{
					PM.animator.SetBool("Slide",false);
				}
			}
			
			// Jump 버튼 
			if(GUI.Button(new Rect(Screen.width/32 *27  ,Screen.height/16*13,Screen.width/8,Screen.height/16*3), Jump)) {
				if(PM.Player_Status !=5){
					PM.Player_Status=1;
					PM.GetComponent<AudioSource>().clip = PM.Jump_BGM;
					PM.GetComponent<AudioSource>().Play();
				}
			}
			
			// Menu 버튼
			if(GUI.Button(new Rect(Screen.width/32 *27  ,Screen.height/16,Screen.width/8,Screen.height/8), Menu,GUIStyle.none)) {
				GS = GameState.Pause;
				Time.timeScale=0;
								
			}
		}
		if (GS == GameState.Pause) {
			GetComponent<AudioSource>().Pause();
			if(GUI.Button(new Rect (Screen.width / 8 *3, Screen.height /10,Screen.width/8*2, Screen.height /5),Play,GUIStyle.none)){
				Time.timeScale = 1;
				GS=GameState.Play;
				GetComponent<AudioSource>().Play ();
			}
			if(GUI.Button(new Rect (Screen.width / 8 *3, Screen.height /10*4,Screen.width/8*2, Screen.height /5),Restart,GUIStyle.none)){
				Time.timeScale = 1;
				Application.LoadLevel(2);
			}
			if(GUI.Button(new Rect (Screen.width / 8 *3, Screen.height /10*7,Screen.width/8*2, Screen.height /5),Exit,GUIStyle.none)){
				Time.timeScale = 1;
				Application.LoadLevel(0);
			}


		}
		if(GS== GameState.End){
			Application.LoadLevel(3);
		}

	}//OnGUI
}//The End
