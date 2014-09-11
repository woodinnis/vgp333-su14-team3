using UnityEngine;
using System.Collections;

public class CarCollision : MonoBehaviour {

	private Collision target;

	//void FixedUpdate()
	//{
		
	//}

	void OnCollisionEnter (Collision collision)
	{
		//target = collision;
		collision.rigidbody.AddForce (Vector3.back * Time.deltaTime);
	}

}

