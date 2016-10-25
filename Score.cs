using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {
	
	public GUIText Scoretext;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		Scoretext.text = (Time.timeSinceLevelLoad* 10 * Time.timeSinceLevelLoad * 1.0f).ToString("N0");
		
	}
}