using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class ObstacleController : MonoBehaviour
{
    Camera camera;  // main camera
    bool activated;  // the agent is activated if the mouse has clicked on it.
                     // it gets deactivated if the mouse clicks again.
    Color deactivatedColor;
    Color activatedColor;
    float dz = 1;
    float dx = 1;
    float dy = 1;
    List<string> childrenNames;
    // Start is called before the first frame update
    void Start()
    {
        // set the agent referring to self
        // agent = GetComponent<NavMeshAgent>();
        camera = Camera.main;
        activated = false;
        deactivatedColor = new Color(GetComponentInChildren<Renderer>().material.color.r,
                                    GetComponentInChildren<Renderer>().material.color.g,
                                    GetComponentInChildren<Renderer>().material.color.b,
                                    GetComponentInChildren<Renderer>().material.color.a);
        activatedColor = new Color(GetComponentInChildren<Renderer>().material.color.r,//-0.4f, 
                                    GetComponentInChildren<Renderer>().material.color.g,//-0.4f, 
                                    GetComponentInChildren<Renderer>().material.color.b - 0.6f,//-0.3f, 
                                    GetComponentInChildren<Renderer>().material.color.a);
    }

    // Update is called once per frame
    void Update()
    {
        // Once the obstacle is selected, can use arrow key to move it around
        if (activated)
        {

            if (Input.GetKey("up"))
            {
                Vector3 current_pos = this.transform.position;
                current_pos[2] = current_pos[2] + dz;
                this.transform.position = current_pos;
            }
            if (Input.GetKey("down"))
            {
                Vector3 current_pos = this.transform.position;
                current_pos[2] = current_pos[2] - dz;
                this.transform.position = current_pos;
            }
            if (Input.GetKey("left"))
            {
                Vector3 current_pos = this.transform.position;
                current_pos[0] = current_pos[0] - dx;
                this.transform.position = current_pos;
            }
            if (Input.GetKey("right"))
            {
                Vector3 current_pos = this.transform.position;
                current_pos[0] = current_pos[0] + dx;
                this.transform.position = current_pos;
            }
        }
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                //Debug.Log("game object: " + hit.collider.gameObject.name);
                //Debug.Log(childrenNames.IndexOf(hit.collider.gameObject.name));
                //Debug.Log("hit current object: " + (childrenNames.IndexOf(hit.collider.gameObject.name) != -1));
                Debug.Log("hit object: " + hit.transform.name);
                Debug.Log("hit object parent: " + hit.transform.parent.name);

                if (hit.transform.name == this.name || hit.transform.parent.name == this.name)
                {
                    // if the mouse selects the current player, change activation
                    activated = (!activated);
                    if (activated)
                    {
                        // change color so we know it's activated
                        GetComponentInChildren<Renderer>().material.color = activatedColor;
                    }
                    else
                    {
                        GetComponentInChildren<Renderer>().material.color = deactivatedColor;

                    }
                }
            }
        }

    }
}
