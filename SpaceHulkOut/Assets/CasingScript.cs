using UnityEngine;
using System.Collections;

public class CasingScript : MonoBehaviour {
	float speed = 50;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		Vector3 velocity = this.gameObject.transform.forward;
		Ray ray = new Ray(this.gameObject.transform.position, this.gameObject.transform.forward);
		RaycastHit hit;
		if(Physics.Raycast(ray, out hit, (Time.deltaTime * speed )* .1f)){
			Vector3 reflectDir = Vector3.Reflect(ray.direction, hit.normal);
			//			velocity = 2 * ( Vector3.Dot( velocity, Vector3.Normalize( hit.normal ) ) ) * Vector3.Normalize( hit.normal ) - velocity; //Following formula  v' = 2 * (v . n) * n - v
			//			
			//			velocity *= -1; 
			this.gameObject.GetComponent<Rigidbody>().AddForce(reflectDir * 500f);
		}

	}

	void OnCollisionEnter(Collision col){
		//gameObject.GetComponent<AudioSource> ().Play ();

	}
}
