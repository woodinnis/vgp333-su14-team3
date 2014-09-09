using UnityEngine;
using System.Collections;

public class CarCollision : MonoBehaviour {

	private Collision target;

	void FixedUpdate()
	{
		target.rigidbody.AddForce (Vector3.back);
	}

	void OnCollisionEnter (Collision collision)
	{
		target = collision;
	}

}

