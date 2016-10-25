using UnityEngine;
using System.Collections;

public class TitleMenu : MonoBehaviour {
	public Texture2D Game_Start;
	public Texture2D Option;

	public AudioClip MainTheme;
	// Use this for initialization
	void Start () {
		GetComponent<AudioSource>().clip = MainTheme;
		GetComponent<AudioSource>().Play ();
	}
	
	// Update is called once per frame
	void Update () {

	}
	void OnGUI(){
		if(GUI.Button(new Rect (Screen.width /4 *3 - Screen.width /30 , Screen.height / 2 ,Screen.width /4,Screen.height/4),Game_Start,GUIStyle.none)){
			Application.LoadLevel(2);
		}
		if(GUI.Button(new Rect (Screen.width /4 *3 - Screen.width /30 , Screen.height / 4 *3 ,Screen.width /4,Screen.height/4),Option,GUIStyle.none)){
			Application.LoadLevel(1);
		}


	}
}
