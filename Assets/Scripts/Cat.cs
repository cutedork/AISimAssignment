using UnityEngine;
using System.Collections;

public class Cat : MonoBehaviour {

	// declare a public variable, of type Transform, called "mouse"
	public Transform mouse;

	Rigidbody rb;
	
	void Start () {
		rb = GetComponent<Rigidbody>();
	}
	

	void FixedUpdate () {

		if (mouse == null) {
			return;
		}

		// declare a var of type Vector3, called "directionToMouse", 
		// set to a vector that goes from [current position] to [mouse's current position]
		Vector3 directionToMouse = mouse.position - transform.position;
		float distanceToMouse = Vector3.Distance(mouse.position, transform.position);

		// if the angle between [current forward direction] vs [directionToMouse] is less than 90 degrees,

		float angle = Vector3.Angle (transform.forward, directionToMouse); 
		if (angle < 90f  || distanceToMouse < 5f) {

			// then declare a var of type Ray, called "catRay" that starts from
			// current position and goes along [directionToMouse]
			Ray catRay = new Ray(transform.position, directionToMouse); 

			// declare a var of type RaycastHit, called "catRayHitInfo"
			RaycastHit catRayHitInfo = new RaycastHit(); 

			// if raycast with catRay and catRayHitInfo for 100 units is TRUE... 
			if (Physics.Raycast (catRay, out catRayHitInfo, 100f) ) {

				// if catRayHitInfo.collider.tag is exactly equal to the word "Mouse" (cat sees the mouse!)
				if (catRayHitInfo.collider.tag == "Mouse" ) {

					
					// if catRayHitInfo.distance is less than or equal to 5... 
					if (catRayHitInfo.distance <= 3f) {

						// then destroy the mouse gameObject (we caught the mouse!) 
						Destroy(mouse.gameObject);

					} else {
						// add force on rigidbody, along [directionToMouse.normalized * 1000f] (chase it!)
						rb.AddForce (directionToMouse.normalized * 1000f);
					}
				}
			}
		}
	}
}
