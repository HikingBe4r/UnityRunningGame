using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour {

	public int Down=4;
	public Texture2D Restart;
	public AudioClip OverBGM ;
	// Use this for initialization
	void Start () {
		GetComponent<AudioSource>().clip = OverBGM;
		GetComponent<AudioSource>().Play ();
	}
	
	// Update is called once per frame
	void Update () {
				if (transform.position.y > 0) {
					transform.Translate (0, -Time.deltaTime * Down, 0);
	
				}

		}

	void OnGUI(){

	if(transform.position.y <= 0){
			if(GUI.Button(new Rect (Screen.width/4*3  , Screen.height/8, Screen.width /4,Screen.height /4),Restart,GUIStyle.none)){
			Application.LoadLevel(0);
			}
		
		}
	}
}
