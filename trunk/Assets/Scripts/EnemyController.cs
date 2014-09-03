using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

	public Transform target;

	private NavMeshAgent agent;


	void Start()
	{
		agent = GetComponent<NavMeshAgent>();

	}

	// Update is called once per frame
	void Update () 
	{
		agent.SetDestination(target.position);
	}
}
