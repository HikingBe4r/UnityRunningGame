using UnityEngine;
using System.Collections;

public class NurseMove : MonoBehaviour {

	public float Movespeed = 2.0f;
	public int time =0 ;		// 초당 60frame
	public float difficulty = 2.0f;

	public int Crash=0;
	public float xPos;

	public MenuInGame GM;
	public PlayerMove PM;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		//실패작 
		//xPos = (PM.gameObject.transform.position.x - PM.HP);
		//transform.Translate (xPos, 0, 0);
		if (PM.HP > 0) {
						if (GM.GS == GameState.Play) {
								if (PM.time % 30 == 0)		//	체력이 깎일때마다 가까워짐 
										transform.Translate (1, 0, 0);
								if (Crash == 1) {			//	부딪히면 10만큼 가까워짐 
									
										transform.Translate (10, 0, 0);
										Crash = 0;
								}
						}
				}



	}
}

