using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentNavigation : MonoBehaviour
{
    //Transform goal;
    NavMeshAgent agent;
    public Camera camera;
    bool activated;  // the agent is activated if the mouse has clicked on it.
                     // it gets deactivated if the mouse clicks again.
    Color deactivatedColor;
    Color activatedColor;

    public float brakingRadius;
    // Start is called before the first frame update
    void Start()
    {
        // set the agent referring to self
        agent = GetComponent<NavMeshAgent>();
        activated = false;
        deactivatedColor = new Color(GetComponent<Renderer>().material.color.r,
                                    GetComponent<Renderer>().material.color.g,
                                    GetComponent<Renderer>().material.color.b,
                                    GetComponent<Renderer>().material.color.a);
        activatedColor = new Color(GetComponent<Renderer>().material.color.r,//-0.4f, 
                                    GetComponent<Renderer>().material.color.g,//-0.4f, 
                                    GetComponent<Renderer>().material.color.b-0.6f,//-0.3f, 
                                    GetComponent<Renderer>().material.color.a);
    }

    // Update is called once per frame
    void Update()
    {
        // If we capture a mouse click, then we check if the goal is the same.
        // If the goal has changed, we will set the goal to the new location.
        
        if (activated && Input.GetMouseButtonDown(1))
        {
            RaycastHit hit;
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                //Transform objectHit = hit.transform;
                Vector3 hitPosition = hit.point;
                //if ((goal.position - hitPosition).sqrMagnitude >= 0.1f)
                {
                    // the goal position has changed, reset
                    //goal.position = hitPosition;
                    agent.destination = hitPosition;
                    agent.stoppingDistance = brakingRadius;
                }
            }
        }
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject == this.gameObject)
                {
                    // if the mouse selects the current player, change activation
                    activated = (!activated);
                    if (activated)
                    {
                        // change color so we know it's activated
                        GetComponent<Renderer>().material.color = activatedColor;
                    }
                    else
                    {
                        GetComponent<Renderer>().material.color = deactivatedColor;

                    }
                }
            }
        }
    }
}
