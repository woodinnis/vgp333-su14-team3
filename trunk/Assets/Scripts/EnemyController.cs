using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

	public Transform[] target;

	private NavMeshAgent agent;
	private int currentDestination;

	void Start()
	{
		agent = GetComponent<NavMeshAgent>();

		currentDestination = 0;
	}

	// Update is called once per frame

	void Update () 
	{
		if(agent.remainingDistance <= 0)
		{
			print("Distance Remaining: " + agent.remainingDistance);

			// Use to create a looping "patrol" behaviour
			if(currentDestination >= target.Length)
				currentDestination = 0;
			else
				currentDestination++;

			// Use to create a random walkabout behaviour
			//currentDestination = Random.Range(0,target.Length);

			agent.SetDestination(target[currentDestination].position);
		}
	}

}
