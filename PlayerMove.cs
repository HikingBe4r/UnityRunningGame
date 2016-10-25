using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {
	

	public float jumpspeed = 1.0f;

	public Animator animator;   // 애니메이션 스프라이트 집합소
	public int Player_Status;  // 상태 정의 enum으로 하는게 더 많아지고 좋겠지.

	public int time =0;
	public int jumptime=0;
	public int Slidetime = 0;
	public int Fever=0;
	public int Fevertime = 0;
	public int HP=100;
	public int CrashTime =0;
	public int EndTime = 1;
	public int GameOverHP;
	public int CrashCount = 0;
	public int GameEnd =0;

	public float Gravity = 0;

	public AudioClip Jump_BGM;
	public AudioClip Slide_BGM;
	public AudioClip Crash1;
	public AudioClip Boost;
	public AudioClip GetCoin;
	public AudioClip GameOver_BGM;

	public GUITexture graphic;
	public Texture2D standard;
	public Texture2D downgfx;
	public Texture2D upgfx;
	public Texture2D heldgfx;


	public MenuInGame GM;
	public NurseMove NM;

	void Start () {
		// 0: Run, 1: Jump, 2: Slide, 3: Crash, 4: Gameover, 5: Fever
		Player_Status = 0;
	}

	void Update () {
		if (time % 30 == 0)
			HP--;
		time++;

		// Status : 0 - Run
		if (Player_Status == 0) 
		{
			GetComponent<AudioSource>().Stop ();
			animator.SetBool ("Jump", false);
			animator.SetBool ("Slide", false);
			animator.SetBool ("Crash", false);
			//animator.SetBool ("Slide", false);
			jumptime = 0;
		}

		if (Player_Status != 1 &&gameObject.transform.position.y > -3.9f) 
		{
			gameObject.transform.Translate (0, -jumpspeed * Time.deltaTime * 20, 0);		
		}

		if (Player_Status != 5) 
		{
			// Status : 1 - Jump
			if (Input.GetButtonDown ("Jump")) {
				GetComponent<AudioSource>().Stop ();
				GetComponent<AudioSource>().clip = Jump_BGM;
				GetComponent<AudioSource>().Play ();
				Player_Status = 1;
			}
			if (Player_Status == 1) {
				animator.SetBool ("Jump", true); 
				animator.SetBool ("Slide", false);
					
				if (jumptime % 70 < 35)
					gameObject.transform.Translate (0, jumpspeed * Time.deltaTime * 15, 0);
				else
					gameObject.transform.Translate (0, -jumpspeed * Time.deltaTime * 20, 0);
			}
			jumptime++;

			// Status : 2 - Slide
			if (Input.GetButtonDown ("Slide")) 
			{
				Player_Status = 2;
				GetComponent<AudioSource>().Stop ();
				GetComponent<AudioSource>().clip = Slide_BGM;
				GetComponent<AudioSource>().Play ();
			}
			if (Player_Status == 2) 
			{
				//if (Input.GetButton ("Slide")) {
				animator.SetBool ("Slide", true);
				//}
				Slidetime++;
				if (Slidetime % 40 == 0) 
				{
					Player_Status = 0;
				}
			}
		}

		// Status : 3 - Crash
		if (Player_Status == 3) 
		{
			animator.SetBool ("Crash", true);
			Gravity = -2.0f;

			if (CrashTime % 60 == 0) 
			{
				Player_Status = 0;
				HP -= 10;
				NM.Crash = 1;
			}
			CrashTime++;		
		}

		// Status : 4 - GameOver
		if (NM.transform.position.x == -30) {
			GetComponent<AudioSource>().clip = GameOver_BGM;
			GetComponent<AudioSource>().Play();
				}
		if (HP < 1) 
		{
			Player_Status = 4;
			EndTime++;
		}
		if (Player_Status == 4) 
		{
			animator.SetBool ("GameOver", true);
			if(EndTime > 200)
				GM.GS = GameState.End;
		}

		// Status : 5 - Fever
		if (Fever >= 100) 
		{
			Player_Status = 5;
			GetComponent<AudioSource>().Stop ();
			GetComponent<AudioSource>().clip = Boost;
			GetComponent<AudioSource>().Play ();
			Fever = 0;
		}
		if (Player_Status == 5) 
		{
			animator.SetBool ("Jump", false);
			animator.SetBool ("Slide", false);
			animator.SetBool ("Crash", false);
			animator.SetBool ("Fever", true);

			if (Fevertime >= 240) 
			{
				animator.SetBool ("Fever", false);
				Player_Status = 0;

				Fevertime = 0;
				//audio.Stop();
			}
			Fevertime++;
			if(HP <1)
				Player_Status=4;
		}

	}

	void OnCollisionEnter2D(Collision2D collision){            //    2D랑 3D랑 충돌 함수가 다름.
			                                                   //    오브젝트도 2D로 만들어야됨.
		if (Player_Status != 5) 
		{
			if (collision.gameObject.CompareTag ("Ground")) 
			{	
				Player_Status = 0;
				Gravity = 0;
			}
		}
	}// void OnCollisionEnter2D

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "Coin")
		{
			Fever+=7;
			Destroy(col.gameObject);
			if(Player_Status!=5)
			{
				GetComponent<AudioSource>().Stop();
				GetComponent<AudioSource>().clip=GetCoin;
				GetComponent<AudioSource>().Play ();
			}
		}
		if (Player_Status != 5) {
			if (col.gameObject.tag == "Enemy") {	
				Player_Status = 3;
				GetComponent<AudioSource>().Stop();
				GetComponent<AudioSource>().clip=Crash1;
				GetComponent<AudioSource>().Play ();
				CrashCount = 1;
				Destroy(col.gameObject);
			}
		}
		if (Player_Status == 5) {
			if(col.gameObject.tag =="Enemy")
				Destroy(col.gameObject);
		}
	}//void OnTriggerEnter2D(Collider2D col)


}//class