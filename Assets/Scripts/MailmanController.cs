using UnityEngine;
using System.Collections;

public class MailmanController : MonoBehaviour
{
	private enum State
	{
		Patrol,
		Aggro,
		Attack
	}
	
	public float moveSpeed;
	public float turnSpeed;
	public float alertDistance;
	private Transform myTransform;
	private Transform myTarget;
	private State currentState;
	public Transform[] target;
	private NavMeshAgent agent;
	private int currentDestination;
	
	void Start()
	{
		myTransform = transform;
		currentState = State.Patrol;
		agent = GetComponent<NavMeshAgent>();
		currentDestination = 0;
	}
	
	void Update()
	{
		UpdatePerception();
		UpdateFSM();
	}
	
	private void UpdatePerception()
	{
		GameObject player = GameObject.FindGameObjectWithTag("Player");
		float distance = Vector3.Distance(myTransform.position, player.transform.position);
		if (distance < alertDistance)
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
		switch (currentState)
		{
		case State.Patrol:
			UpdatePatrol();
			break;
		case State.Aggro:
			UpdateAggro();
			break;
		case State.Attack:
			UpdateAttack();
			break;
		}
	}
	
	private void UpdatePatrol()
	{
		if(agent.remainingDistance <= 0)
		{
			print("Distance Remaining: " + agent.remainingDistance);
			
			// Use to create a looping "patrol" behaviour
			currentDestination++;
			
			if(currentDestination >= target.Length)
				currentDestination = 0;
			
			// Use to create a random walkabout behaviour
			//currentDestination = Random.Range(0,target.Length);
			
			agent.SetDestination(target[currentDestination].position);
		}
	}
	
	private void UpdateAggro()
	{
		Vector3 meToTarget = myTarget.position - myTransform.position;
		Vector3 dirToTarget = new Vector3(meToTarget.x, 0f, meToTarget.z);
		//Quaternion startRot = myTransform.rotation;
		//Quaternion finalRot = Quaternion.LookRotation(dirToTarget, Vector3.up);
		//myTransform.rotation = Quaternion.RotateTowards(startRot, finalRot, turnSpeed * Time.deltaTime);
		
		Vector3 startPos = myTransform.position;
		Vector3 finalPos = myTarget.position;
		myTransform.position = Vector3.MoveTowards(startPos, finalPos, moveSpeed * Time.deltaTime);

		if(Vector3.Distance(startPos, finalPos) < 1.0f )
		{
			currentState = State.Attack;

		}

	}

	private void UpdateAttack()
	
	{
		//reduce happinesss :( Player.happiness -= 20;
		currentState = State.Patrol;
	}
}
