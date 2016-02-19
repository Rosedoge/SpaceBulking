using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {


	[SerializeField] GameObject[] Spawners;
	GameObject[] Smoke;
	public  GameObject Player;

	bool testTrigger = false;
	float timer;
	float Enemytimer;
	public int levelNum = 0, killed = 0;
	// Use this for initialization
	void Start () {
		Smoke = GameObject.FindGameObjectsWithTag ("Smoke");
		//Spawners = GameObject.FindGameObjectsWithTag ("Spawner");
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time - timer > 3f) {
			int rando = Random.Range (0, 3);
			Smoke [rando].gameObject.GetComponent<ParticleSystem> ().Play ();
			Smoke [rando].gameObject.GetComponent<AudioSource> ().Play ();
			timer = Time.time;
		}
		if (Time.time - Enemytimer > 7f) {
			Spawn ();
			Enemytimer = Time.time;

		}
		//Debug.Log ("killed: " + killed);
		if (killed >= 2 && !testTrigger) {
			Player.gameObject.GetComponent<Player> ().MoveOn (levelNum += 1);
			testTrigger = true;
		}
	}

	public void Spawn(){

		if (levelNum == 0) {
			int rando = Random.Range (0, 3);
			//Debug.Log (rando + " is spawner");
			Spawners [rando].gameObject.GetComponent<Spawner> ().SpawnEnemy ();
		

		}
		if (levelNum == 1) {
			int rando = Random.Range (2, 6);
			Spawners [rando].gameObject.GetComponent<Spawner> ().SpawnEnemy ();


		}
	}
}
