using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	[SerializeField] GameObject Gun;
	[SerializeField] GameObject GunEnd;
	[SerializeField] GameObject Casing;
	[SerializeField] GameObject Flash;
	public GameObject BulletPrefab;
	public GameObject PlayerCam;
	//bool shooting = false;

	MeshRenderer[] FlashKids;
	GameObject casingClone;// = Casing.gameObject;
	void Start () {
		casingClone = Casing.gameObject;
		FlashKids = Flash.gameObject.GetComponentsInChildren <MeshRenderer>();
		FlashOff ();
	}

	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.Mouse0)) {
			Gun.gameObject.GetComponent<Animator> ().SetTrigger ("Shooting");
			Gun.gameObject.GetComponent<Animator> ().ResetTrigger ("NotShooting");

		}
		if (Input.GetKeyUp (KeyCode.Mouse0)) {
			//print ("space key was released");
			Gun.gameObject.GetComponent<Animator> ().SetTrigger ("NotShooting");
			Gun.gameObject.GetComponent<Animator> ().ResetTrigger ("Shooting");
			FlashOff ();
		}
	}

	/// <summary>
	/// Ejects the casing.
	/// Because we can't animate well
	/// Create a new gameobject with the same transform as casing, remove the  constraints on the original one, addforce, wait, delete, maybe not delete
	/// </summary>

	public void FlashOn(){
		foreach(MeshRenderer mesh in FlashKids){
			mesh.enabled = true;

		}

	}
	public void FlashOff(){
		foreach(MeshRenderer mesh in FlashKids){
			mesh.enabled = false;;

		}

	}
	public void EjectCasing(){
		GameObject cas2 = (GameObject)Instantiate(BulletPrefab, GunEnd.gameObject.transform.position, GunEnd.gameObject.transform.rotation);
		GameObject cas = (GameObject)Instantiate(casingClone, Casing.gameObject.transform.position, Casing.gameObject.transform.rotation);
		cas.gameObject.GetComponent<MeshRenderer> ().enabled = true;
		cas.gameObject.GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.None;
		cas.gameObject.GetComponent<Rigidbody> ().AddRelativeForce (new Vector3 (50.5f, 1f, 0f));
		Vector3 point = Camera.main.transform.position + Camera.main.transform.forward * 10;
		Vector3 dir = (point - GunEnd.gameObject.transform.position).normalized;
		cas2.gameObject.GetComponent<Rigidbody> ().AddForce(dir * 500);
		//cas2.gameObject.GetComponent<Rigidbody> ().AddForce (GunEnd.gameObject.transform.forward*100);


	}
}
	 //Use this for initialization

//	
//	// Update is called once per frame
//	void Update () {
//		
//		transform.LookAt(mycam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, mycam.nearClipPlane)), Vector3.up);
//	}
//}
