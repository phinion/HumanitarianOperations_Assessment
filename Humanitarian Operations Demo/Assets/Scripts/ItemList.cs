using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemList : MonoBehaviour
{
	public static ItemList instance;

	void Awake()
	{

		if (instance != null)
		{
			Debug.Log("More than one instance of list of items found!");
			return;
		}

		instance = this;
	}

	public List<GameObject> itemGameObjectsList = new List<GameObject>();
}
