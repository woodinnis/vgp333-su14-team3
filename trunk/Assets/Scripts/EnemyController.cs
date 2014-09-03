using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

	public GameObject seekMe;

	private NavMeshAgent agent;
	private Vector3 target;

	void Start()
	{
		agent = GetComponent<NavMeshAgent>();

	}

	// Update is called once per frame
	void Update () {
		target = seekMe.transform.position;
		agent.SetDestination(target);
	}
}
