using UnityEngine;
using System.Collections;

public class PathManager : MonoBehaviour {

	[HideInInspector]
	public static PathManager instance;

	public GameObject[] nodeList;

	// Use this for initialization
	void Awake () 
	{
		instance = this;			
	}
	
	public Transform NewNode(Transform here)
	{
		foreach(GameObject TestHouse in nodeList)
		{
			if(TestHouse.transform != here.transform)
			{
				Transform newNode = Instantiate (TestHouse) as Transform;

				return newNode;
			}

		}
		Debug.Log("House: " + name + " not found.");
		return null;
	}


	// Update is called once per frame
	void Update () {
	
	}
}
