using UnityEngine;
using System.Collections;

public class MapMove : MonoBehaviour {


	public float Movespeed = 1000;
	public int time =0 ;
	public float difficulty = 1.5f;

	public PlayerMove PM;
	public MenuInGame GM;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (GM.GS == GameState.Play) {
						transform.Translate (-Movespeed / 1000, 0, 0);

						if (transform.position.x < -76.8f) {
								transform.Translate (153.6f, 0, 0);
						}
						if (PM.Player_Status == 5) {
								Movespeed = 2000;
						}
						if (PM.Player_Status == 0)
								Movespeed = 1000;
						//	if (Movespeed < 750) {
						//					if (time % 1000 == 0)
						//							Movespeed *= difficulty;
						//			}

				}
	}//void Update
}//class