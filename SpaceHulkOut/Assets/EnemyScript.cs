using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour {
	public GameObject controller;
	public GameObject Blood;
	[SerializeField] GameObject Player;
	int Health = 5;
	// Use this for initialization
	void Start () {
		gameObject.GetComponent<NavMeshAgent> ().destination = controller.gameObject.GetComponent<GameController>().Player.transform.position;
	}
	void OnParticleCollision(GameObject particle){
		
		Health -= 1;
		GameObject cas = (GameObject)Instantiate(Blood, particle.gameObject.transform.position, particle.gameObject.transform.rotation);

	}

	void OnCollisionEnter(Collision	col){
		if (col.gameObject.tag == "Bullet") {
		//	Debug.Log (Health);
			Health -= 1;
			GameObject cas = (GameObject)Instantiate(Blood, col.gameObject.transform.position, col.gameObject.transform.rotation);

			Destroy (col.gameObject);
		}
	}

	// Update is called once per frame
	void Update () {

		if (Health <= 0) {
		//	Debug.Log ("Dies??");
			controller.gameObject.GetComponent<GameController> ().Spawn ();
			controller.gameObject.GetComponent<GameController> ().killed += 1;
			controller.gameObject.GetComponent<GameController> ().enemies.Remove (this.gameObject);
			gameObject.GetComponent<BoxCollider> ().enabled = false;
			Destroy (this.gameObject);

		}
	
	}
}



