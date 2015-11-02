using UnityEngine;
using System.Collections;

public class Mouse : MonoBehaviour {

	// declare a public variable, of type Transform, called "cat"

	public Transform cat;

	 Rigidbody rb;

	void Start () {
		rb = GetComponent<Rigidbody>();
	}
	
	void FixedUpdate () {
		// declare a var of type Vector3, called "directionToCat", set to a vector
		// that goes from [current position] to [cat's current position]

		Vector3 directionToCat = cat.position - transform.position; //new Vector3(transform.position, cat.position); 

		// if the angle between [current forward direction] vs. [directionToCat] is less than
		// 180 degrees, then... 
		float angle = Vector3.Angle (transform.forward, directionToCat); 

		if (angle < 180f) {
		
			// declare a var of type Ray, called "mouseRay" that starts from 
			// [current position] and goes along [directionToCat]

			Ray mouseRay = new Ray (transform.position, directionToCat); 

			// declare a var of type RaycastHit, called "mouseRayHitInfo" 

			RaycastHit mouseRayHitInfo = new RaycastHit(); 

			// if raycast with mouseRay and mouseRayHitInfo for 100 units is TRUE, then... 

			if (Physics.Raycast (mouseRay, out mouseRayHitInfo, 100f) ) {

				// if mouseRayHitInfo.collider.tag is exactly equal to the word "Cat" 
				// ... (mouse sees cat!)
				if (mouseRayHitInfo.collider.tag == "Cat") {
					// add force on rigidbody, along [-directionToCat.normalized * 1000f] (run away!)
					rb.AddForce(-directionToCat.normalized * 1000f); 
				}
			}
		}
	}
}
