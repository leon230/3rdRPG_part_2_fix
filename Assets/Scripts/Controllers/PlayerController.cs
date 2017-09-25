using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{

    public LayerMask movementMask;
    public Interactable actualFocus;

    Camera camera;
    PlayerMotor playerMotor;

    // Use this for initialization
    void Start()
    {
        camera = Camera.main;
        playerMotor = GetComponent<PlayerMotor>();
    }

    // Update is called once per frame
    void Update()
    {
		//Check if cursor is above object like inventory to stop moving the character

		if (EventSystem.current.IsPointerOverGameObject()) {
			return;
		}


        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100, movementMask))
            {
                playerMotor.MoveToPoint(hit.point);


                //Stop focusing any obejcts
                removeFocus();

            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100))
            {
                //Check if interactable
               Interactable interactable = hit.collider.GetComponent<Interactable>();

                if (interactable != null)
                {
                    setFocus(interactable);
                }

            }
        }
    }

    void setFocus (Interactable newFocus)
    {

        if(newFocus != actualFocus)
        {
            if (actualFocus != null)
            {
                actualFocus.OnDefocused();
            }
            
            playerMotor.FollowTarget(newFocus);
            actualFocus = newFocus;
        }

        newFocus.OnFocus(transform);
        
    }

    void removeFocus()
    {
        if (actualFocus != null)
        {
            actualFocus.OnDefocused();
        }
        
        actualFocus = null;
        playerMotor.StopFollowingTarget();
    }
}
