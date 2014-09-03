using UnityEngine;
using System.Collections;

public class AIController : MonoBehaviour
{

	private enum State
	{
		Idle,
		Chase
	}

	public float moveSpeed;
	public float turnSpeed;
	public float alertDistance;

	private State currentState;
	private Transform myTransform;
	private Transform myTarget;

	// Use this for initialization
	void Start()
	{
		myTransform = transform;
		currentState = State.Idle;
	}

	// Update is called once per frame
	void Update()
	{
		UpdatePerception();
		UpdateFSM();
	}

	private void UpdatePerception()
	{
		GameObject player = GameObject.FindGameObjectWithTag("Player");
		float distance = Vector3.Distance (myTransform.position, player.transform.position);
		if( distance < alertDistance)
		{
			myTarget = player.transform;
		}
		else
		{
			myTarget = null;
		}
	}

	private void UpdateFSM()
	{
		switch(currentState)
		{
		case State.Idle:
			UpdateIdle();
			break;
		case State.Chase:
			UpdateChase();
			break;
		}
	}

	private void UpdateIdle()
	{
		myTransform.Rotate (Vector3.up, turnSpeed * Time.deltaTime);

		if(myTarget != null)
		{
			currentState = State.Chase;
		}
	}

	private void UpdateChase()
	{
		if(myTarget == null)
		{
			currentState = State.Idle;
		}
		else
		{
			Vector3 meToTarget = myTarget.position - myTransform.position;
			Vector3 dirToTarget = new Vector3(meToTarget.x, 0f, meToTarget.z);
			Quaternion startRot = myTransform.rotation;
			Quaternion finalRot = Quaternion.LookRotation(dirToTarget,Vector3.up);

			myTransform.rotation = Quaternion.RotateTowards(startRot, finalRot, turnSpeed * Time.deltaTime);

			Vector3 startPos = myTransform.position;
			Vector3 finalPos = myTarget.position;

			myTransform.position = Vector3.MoveTowards(startPos, finalPos, moveSpeed * Time.deltaTime);


		}
	}
}

