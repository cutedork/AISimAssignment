using UnityEngine;
using System.Collections;

public class Cat : MonoBehaviour {

	// declare a public variable, of type Transform, called "mouse"
	//public Transform listOfMice[x];

	// audio 
	public AudioSource evilLaugh;
	public AudioSource scream;

	Rigidbody rb;
	
	void Start () {
		rb = GetComponent<Rigidbody>();
	}
	

	void FixedUpdate () {
		for (int x = 0; x < GameManager.listOfMice.Count; x++ ) { 

			if (GameManager.listOfMice[x] == null) {
				return;
			}

			// declare a var of type Vector3, called "directionToMouse", 
			// set to a vector that goes from [current position] to [mouse's current position]
			Vector3 directionToMouse = GameManager.listOfMice[x].transform.position - transform.position;
			float distanceToMouse = Vector3.Distance(GameManager.listOfMice[x].transform.position, transform.position);

			// if the angle between [current forward direction] vs [directionToMouse] is less than 90 degrees,

			float angle = Vector3.Angle (transform.forward, directionToMouse); 
			if (angle < 90f  || distanceToMouse < 2f) {

				// then declare a var of type Ray, called "catRay" that starts from
				// current position and goes along [directionToMouse]
				Ray catRay = new Ray(transform.position, directionToMouse); 

				// declare a var of type RaycastHit, called "catRayHitInfo"
				RaycastHit catRayHitInfo = new RaycastHit(); 

				// if raycast with catRay and catRayHitInfo for 100 units is TRUE... 
				if (Physics.Raycast (catRay, out catRayHitInfo, 100f) ) {

					// if catRayHitInfo.collider.tag is exactly equal to the word "Mouse" (cat sees the mouse!)
					if (catRayHitInfo.collider.tag == "Mouse" ) {
						// play evil laugh sound
						evilLaugh.Play ();

						
						// if catRayHitInfo.distance is less than or equal to 5... 
						if (catRayHitInfo.distance <= 1f) {

							// then destroy the mouse gameObject (we caught the mouse!) 
							//Destroy(listOfMice[x].gameObject);
							// play scream sound
							Destroy (catRayHitInfo.collider.gameObject);

							scream.Play ();

						} else {
							// add force on rigidbody, along [directionToMouse.normalized * 1000f] (chase it!)
							rb.AddForce (directionToMouse.normalized * 1000f);
						}
					}
				}
			}
		} // end of for loop
	} // end of fixedUpdate
	
}
