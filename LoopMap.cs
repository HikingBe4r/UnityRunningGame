using UnityEngine;
using System.Collections;

public class LoopMap : MonoBehaviour {

	public GameObject[] LoopMaps;
	public GameObject LoopMap1;
	public GameObject LoopMap2;
	//public GameObject LoopMap3;

	public float Speed = 5f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		MOVE();


	}

	public void MAKE(){
		
		LoopMap2=LoopMap1;
		int a = Random.Range(0,5);
		LoopMap1 = Instantiate(LoopMaps[a], new Vector3(30,0,0), transform.rotation) as GameObject;
		
	}
	
	//움직이자
	public void MOVE(){
		
		LoopMap1.transform.Translate(Vector3.left * Speed *Time.deltaTime, Space.World);
		LoopMap2.transform.Translate(Vector3.left * Speed *Time.deltaTime, Space.World);
		
		if(LoopMap1.transform.position.x<=-76.8){
			DEATH();
		}
	}

		
	
	//없애자
	public void DEATH(){
		Destroy(LoopMap2);
		MAKE();

	}
}
