using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour {
	public GameObject controller;
	public GameObject Blood;
	[SerializeField] GameObject Player;
	int Health = 5;
	// Use this for initialization
	void Start () {
		gameObject.GetComponent<NavMeshAgent> ().destination = Player.gameObject.transform.position;
	}

	void OnCollisionEnter(Collision	col){
		if (col.gameObject.tag == "Bullet") {
			Debug.Log (Health);
			Health -= 1;
			GameObject cas = (GameObject)Instantiate(Blood, col.gameObject.transform.position, col.gameObject.transform.rotation);
			Destroy (col.gameObject);
		}

	}
	// Update is called once per frame
	void Update () {

		if (Health <= 0) {
			Debug.Log ("Dies??");
			controller.gameObject.GetComponent<GameController> ().Spawn ();
			Destroy (this.gameObject);

		}
	
	}
}



