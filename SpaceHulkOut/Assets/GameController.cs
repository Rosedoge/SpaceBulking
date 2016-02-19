using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {


	[SerializeField] GameObject[] Spawners;
	GameObject[] Smoke;
	[SerializeField] GameObject Player;

	float timer;
	float Enemytimer;
	// Use this for initialization
	void Start () {
		Smoke = GameObject.FindGameObjectsWithTag ("Smoke");
		Spawners = GameObject.FindGameObjectsWithTag ("Spawner");
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time - timer > 3f) {
			int rando = Random.Range (0, 3);
			Smoke [rando].gameObject.GetComponent<ParticleSystem> ().Play ();
			timer = Time.time;
		}
		if (Time.time - Enemytimer > 7f) {
			Spawn ();
			Enemytimer = Time.time;

		}
	}

	public void Spawn(){
		//if (Time.time - timer > 3f) {
			int rando = Random.Range (0, 3);
			Spawners [rando].gameObject.GetComponent<Spawner> ().SpawnEnemy ();
		//}


	}
}
