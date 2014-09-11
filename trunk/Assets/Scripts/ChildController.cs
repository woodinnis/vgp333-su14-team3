using UnityEngine;
using System.Collections;

public class ChildController : MonoBehaviour 
{
	
	private enum State
	{
		Idle,
		Move,
		Panic
	}
	
	public float moveSpeed;
	public float turnSpeed;
	public float minIdleTime;
	public float maxIdleTime;


	
	private State currentState;
	private Transform myTransform;
	private Vector3 destination;
	private float idleTime;
	
	// Use this for initialization
	void Start()
	{
		myTransform = transform;
		currentState = State.Idle;
		idleTime = Random.Range (minIdleTime, maxIdleTime);
	}
	
	// Update is called once per frame
	void Update()
	{
		UpdateFSM();
	}
	
	private void UpdateFSM()
	{
		switch(currentState)
		{
		case State.Idle:
			UpdateIdle();
			break;
		case State.Move:
			UpdateMove();
			break;
		case State.Panic:
			UpdatePanic();
			break;
		}
	}
	
	private void UpdateIdle()
	{
		idleTime -= Time.deltaTime;
		if(idleTime <= 0.0f)
		{
			currentState = State.Move;
			destination = Playground.instance.navList[Random.Range (0,Playground.instance.navList.Length)].position;
		}
	}
	
	private void UpdateMove()
	{
		//To Do: Move Child to destination, when arrived change state to idle
	}
	private void UpdatePanic()
	{
		
	}
}
