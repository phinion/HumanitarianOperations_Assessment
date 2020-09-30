using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{

	public bool canGrab;
	public float carryDistance = 3.0f;

	public virtual void Interact()
	{
		Debug.Log("Interacting with " + transform.name);
	}

}
