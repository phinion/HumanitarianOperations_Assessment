using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public Joystick MovementJoystick;
    public Joystick LookJoystick;
    public CharacterController controller;
    public GameObject mainCamera;
    public Transform groundCheck;
    public LayerMask groundMask;

    public float speed = 12f;
    public float gravity = -9.81f;
    public float groundDistance = 0.4f;

    Vector3 velocity;
    bool isGrounded;

    public GameObject cameraGameobject;

    public float mouseSensititvity = 100f;
    float xRotation = 0f;

    public GameObject centreObject;

    //Carrying Object Variables
    public GameObject carriedObject;
    public bool carrying = false;
    public float smooth = 10.0f;

    [HideInInspector]
    public Vector2 LookAxis;


    //Main player loop
    void Update()
    {
        CameraLook();
        PlayerMove();
        CheckCentreObject();

        buttonClick();

        if (carrying)
        {
            carry(carriedObject);
        }

    }

    //Checks for screen touch and either grabs/drops an object or interacts with it
    void buttonClick()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (!carrying)
            {
                if (centreObject.GetComponent<Interactable>() != null)
                {
                    grabObject();
                }
            } else {
                dropObject();
            }
        }

        if (centreObject != null && !carrying)
        {
            if (Input.GetMouseButtonDown(0))
            {
                centreObject.GetComponent<Interactable>().Interact();
            }
        }
    }

    // Camera look function
    void CameraLook()
    {

        float mouseX = LookJoystick.Horizontal * mouseSensititvity * Time.deltaTime;
        float mouseY = LookJoystick.Vertical * mouseSensititvity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        cameraGameobject.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        transform.Rotate(Vector3.up * mouseX);
    }

    // player movement function
    void PlayerMove()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = MovementJoystick.Horizontal;
        float z = MovementJoystick.Vertical;

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    // Stores the object that the player is looking at.
    void CheckCentreObject()
    {
        centreObject = null;
        int x = Screen.width / 2;
        int y = Screen.height / 2;

        //if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began) {

        Ray ray = cameraGameobject.GetComponent<Camera>().ScreenPointToRay(new Vector3(x, y));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.distance <= 5.0f)
            {

                if (hit.collider.gameObject.GetComponent<Interactable>())
                {
                    centreObject = hit.collider.gameObject;
                }
            }
        }
        //}
    }

    // Carries gameobjects infront of player
    void carry(GameObject g)
    {
        g.transform.position = Vector3.Lerp(g.transform.position, mainCamera.transform.position + mainCamera.transform.forward * g.GetComponent<Interactable>().carryDistance, Time.deltaTime * smooth);
    }

    // grabs object
    void grabObject()
    {
        if (centreObject.GetComponent<Interactable>().canGrab)
        {
            carrying = true;
            carriedObject = centreObject;
            carriedObject.GetComponent<Rigidbody>().isKinematic = true;
        }
    }

    // drops object
    void dropObject()
    {
        carrying = false;
        carriedObject.gameObject.GetComponent<Rigidbody>().isKinematic = false;
        carriedObject = null;
    }
}
