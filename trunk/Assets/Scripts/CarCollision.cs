using UnityEngine;
using System.Collections;

public class CarCollision : MonoBehaviour {

	//private Collision target;

	//void FixedUpdate()
	//{
		
	//}

	void OnTriggerEnter (Collider other)
	{
		// dog is hit, knocked away from car
		other.rigidbody.AddForce (Vector3.back * 3000);
	}

}

