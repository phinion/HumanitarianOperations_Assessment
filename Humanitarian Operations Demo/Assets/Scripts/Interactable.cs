using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{

	public bool canGrab;
	public float carryDistance = 3.0f;

	//Interactable object which allows virtual void Interact function
	public virtual void Interact()
	{
		Debug.Log("Interacting with " + transform.name);
	}

}
