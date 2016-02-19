using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {
	public GameObject mainController;
	[SerializeField] GameObject Enemy;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void SpawnEnemy(){
		GameObject cas = (GameObject)Instantiate(Enemy, this.gameObject.transform.position, this.gameObject.transform.rotation);
		cas.gameObject.GetComponent<EnemyScript> ().controller = mainController;


	}
}
