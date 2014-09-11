using UnityEngine;
using System.Collections;

public class Playground : MonoBehaviour 
{
	[HideInInspector]
	public static Playground instance;
	
	public Transform[] navList;
	
	void Awake()
	{
		instance = this;
	}
}
