using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public AudioClip Crash;
	public PlayerMove PM;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter2D(Collider2D col)
	{
		if (PM.Player_Status != 5) {
						if (col.gameObject.tag == "Player") {
								GetComponent<AudioSource>().clip = Crash;
								GetComponent<AudioSource>().Play ();
			
						}
				}
	}
}
