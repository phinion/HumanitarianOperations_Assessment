using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : Interactable
{
    public bool ObjOpen = false;
    public Animator animator;

	public override void Interact()
	{
		base.Interact();

			if (ObjOpen == true)
			{
				ObjControl(false);
				ObjOpen = false;
				Debug.Log("Obj Closed");
			}
			else if (ObjOpen == false)
			{
				ObjControl(true);
				ObjOpen = true;
				Debug.Log("Obj Opened");
			}

	}

	void ObjControl(bool _direction)
	{
		animator.SetBool("open", _direction);
		Debug.Log("ObjControl called with direction " + _direction);

	}
}
